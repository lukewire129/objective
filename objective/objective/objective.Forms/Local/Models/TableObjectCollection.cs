﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace objective.Forms.Local.Models
{
        public class TableObjectCollection : ObservableCollection<TableObject>
        {
                private int columns = 1;

                public int Columns
                {
                        get => columns;
                        set
                        {
                                columns = value;
                                OnPropertyChanged();
                        }
                }

                private int rows = 0;

                public int Rows
                {
                        get => rows;
                        set
                        {
                                rows = value;
                                OnPropertyChanged();
                        }
                }

                public void Init()
                {
                        this.Add(new TableObject(enums.TableObjectEnum.Text));
                        this.Columns = 1;
                        this.Rows = 1;
                }

                public void ColumnsAdd()
                {
                        int row = this.Rows;
                        this.Columns += 1;

                        var addCount = (row * this.Columns) - this.Count;

                        for(int i=0; i<addCount; i++)
                        {
                                this.Add(new TableObject(enums.TableObjectEnum.Text));
                        }
                }

                public void RowsAdd()
                {
                        int columns = this.Columns;
                        this.Rows += 1;

                        var addCount = (columns * this.Rows) - this.Count;

                        for (int i = 0; i < addCount; i++)
                        {
                                this.Add(new TableObject(enums.TableObjectEnum.Text));
                        }
                }

                private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                {
                        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
                }
        }
}
