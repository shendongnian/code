    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Data;
    using System.Windows.Forms;
    
    namespace TestSortWithSum
    {
        public class DataTableSumSortableDGV : DataGridView
        {
            /// <summary>
            /// Column index for the sum label.
            /// </summary>
            private int labelColumnIndex = -1;
        
            /// <summary>
            /// Text for the sum label.
            /// </summary>
            private string labelColumnText = string.Empty;
        
            /// <summary>
            /// Constructor. Initialize sort direction and subscribe event.
            /// </summary>
            public DataTableSumSortableDGV() : base()
            {
                this.SumColumnIndices = new ObservableCollection<int>();
                this.Direction = string.Empty;
                this.AllowUserToAddRows = false;
                this.AllowUserToAddRowsChanged += DataTableSumSortableDGV_AllowUserToAddRowsChanged;
                this.DataBindingComplete += DataTableSumSortableDGV_DataBindingComplete;
                this.SumColumnIndices.CollectionChanged += SumColumnIndices_CollectionChanged;
            }
        
            /// <summary>
            /// Text for the sum label.
            /// </summary>
            public string LabelColumnText
            {
                get
                {
                    return this.labelColumnText;
                }
        
                set
                {
                    DataTable table = (DataTable)this.DataSource;
                
                    Action action = () =>
                    {
                        if (this.ShouldSortTable(table))
                        {
                            this.RemoveSumRow(table);
                        }
                        this.labelColumnText = value;
                        if (this.ShouldSortTable(table))
                        {
                            this.AddSumRow(table);
                        }
                    };
                    this.MakeInternalChanges(action);
                }
            }
        
            /// <summary>
            /// Column index for the sum label.
            /// </summary>
            public int LabelColumnIndex
            {
                get
                {
                    return this.labelColumnIndex;
                }
        
                set
                {
                    DataTable table = (DataTable)this.DataSource;
                    Action action = () =>
                    {
                        if (this.ShouldSortTable(table))
                        {
                            this.RemoveSumRow(table);
                        }
                        this.labelColumnIndex = value;
                        if (this.ShouldSortTable(table))
                        {
                            this.AddSumRow(table);
                        }
                    };
                    this.MakeInternalChanges(action);
                }
            }
        
            /// <summary>
            /// Column indices for the sum(s).
            /// </summary>
            public ObservableCollection<int> SumColumnIndices { get; set; }
        
            /// <summary>
            /// The DataTable sort direction.
            /// </summary>
            private string Direction { get; set; }
        
            /// <summary>
            /// DataGridView Sort method.
            /// If DataSource is DataTable, special sort the source.
            /// Else normal sort.
            /// </summary>
            /// <param name="dataGridViewColumn">The DataGridViewColumn to sort by header click.</param>
            /// <param name="direction">The desired sort direction.</param>
            public override void Sort(DataGridViewColumn dataGridViewColumn, System.ComponentModel.ListSortDirection direction)
            {
                DataTable table = (DataTable)this.DataSource;
        
                if (this.ShouldSortTable(table))
                {
                    Action action = () =>
                    {
                        this.RemoveSumRow(table);
        
                        string col = table.Columns[dataGridViewColumn.Index].ColumnName;
        
                        if (!this.Direction.Contains(col))
                        {
                          this.ClearOldSort();
                        }
        
                        string sort = this.Direction.Contains("ASC") ? "DESC" : "ASC";
                        this.Direction = string.Format("{0} {1}", col, sort);
        
                        this.SortRows(table, this.Direction);
                        this.AddSumRow(table);
                    };
        
                    this.MakeInternalChanges(action);
                    dataGridViewColumn.HeaderCell.SortGlyphDirection = this.Direction.Contains("ASC") ? SortOrder.Ascending : SortOrder.Descending;
                }
                else
                {
                    table.DefaultView.Sort = string.Empty;
                    base.Sort(dataGridViewColumn, direction); 
                }
            }
        
            /// <summary>
            /// DataBindingComplete event handler.
            /// Add the sum row when DataSource = a new DataTable.
            /// </summary>
            /// <param name="sender">This DataGridView object.</param>
            /// <param name="e">The DataGridViewBindingCompleteEventArgs.</param>
            private void DataTableSumSortableDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                this.AddInitialSumRow();
            }
            /// <summary>
            /// Prevent users from adding a row as this is DataSourced and rows should be added to the DataTable instead.
            /// </summary>
            /// <param name="sender">The DataGridView object.</param>
            /// <param name="e">The EventArgs.</param>
            private void DataTableSumSortableDGV_AllowUserToAddRowsChanged(object sender, EventArgs e)
            {
                if (this.AllowUserToAddRows)
                {
                    this.AllowUserToAddRows = false;
                }
            }
            /// <summary>
            /// The sum columns have been altered. Reflect the change immediately.
            /// </summary>
            /// <param name="sender">The SumColumnIndices object.</param>
            /// <param name="e">The NotifyCollectionChangedEventArgs.</param>
            private void SumColumnIndices_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                this.AddInitialSumRow();
            }
        
            /// <summary>
            /// Add the sum row for the first time: once the DataTable is sourced and
            /// the label column index, label text, and sum column index are set.
            /// </summary>
            private void AddInitialSumRow()
            {
                DataTable table = (DataTable)this.DataSource;
        
                if (this.ShouldSortTable(table))
                {
                    Action action = () =>
                    {
                        this.RemoveSumRow(table);
                        this.AddSumRow(table);
                    };
        
                    this.MakeInternalChanges(action);
                }
            }
        
            /// <summary>
            /// Add the sum row to the DataTable as a ReadOnly row.
            /// </summary>
            /// <param name="table">The DataTable to add the row to.</param>
            private void AddSumRow(DataTable table)
            {
                List<decimal> sum = this.CreateListOfSums();
        
                // For each row, sum the indicated columns.
                for (int row = 0; row < table.Rows.Count; row++)
                {
                  for (int index = 0; index < this.SumColumnIndices.Count; index++)
                  {
                    try
                    {
                      int col = this.SumColumnIndices[index];
                      sum[index] += Convert.ToDecimal(table.Rows[row].ItemArray[col]);
                    }
                    catch (RowNotInTableException)
                    {
                      continue; // Access attempted to non-committed deleted row.
                    }
                  }
                }
        
                // Create the items array for the new sum row.
                object[] items = new object[table.Rows[0].ItemArray.Length];
                items[this.LabelColumnIndex] = this.LabelColumnText;
        
                for (int index = 0; index < this.SumColumnIndices.Count; index++)
                {
                  int col = this.SumColumnIndices[index];
                  items[col] = sum[index]; 
                }
        
                // Add the sum row as a ReadOnly row.
                table.Rows.Add(items);
        
                if (this.Rows.Count > 0)
                {
                   this.Rows[this.Rows.Count - 1].ReadOnly = true; 
                }
            }
        
            /// <summary>
            /// Clear the old sort string and any set glyph directions in header cells.
            /// </summary>
            private void ClearOldSort()
            {
                if (!string.IsNullOrEmpty(this.Direction))
                {
                    string[] sortVals = this.Direction.Split(new char[] { ' ' }); // [ "ColName", "ASC/DESC" ]
                    this.Columns[sortVals[0]].HeaderCell.SortGlyphDirection = SortOrder.None;
                }
        
                this.Direction = string.Empty;
            }
            /// <summary>
            /// Create a list of sums for each sum column index.
            /// </summary>
            /// <returns>A new list of sums.</returns>
            private List<decimal> CreateListOfSums()
            {
                List<decimal> sum = new List<decimal>();
    
                foreach (int index in this.SumColumnIndices)
                {
                    sum.Add(0m);
                }
    
                return sum;
            }
        
            /// <summary>
            /// Unsubscribe the DataBindingComplete event handler, call internal sorting changes,
            /// then re-subscribe to the DataBindingComplete event handler. This must be done
            /// with any item removal/addition to the DataSource DataTable to prevent recursion
            /// resulting in a Stack Overflow.
            /// </summary>
            /// <param name="operation">The internal changes to be made to the DataSource.</param>
            private void MakeInternalChanges(Action operation)
            {
                this.DataBindingComplete -= DataTableSumSortableDGV_DataBindingComplete;
                operation();
                this.DataBindingComplete += DataTableSumSortableDGV_DataBindingComplete;
            }
        
            /// <summary>
            /// Remove any existing sum row.
            /// </summary>
            /// <param name="table">The DataTable to remove the row from.</param>
            private void RemoveSumRow(DataTable table)
            {
                int last = table.Rows.Count - 1;
        
                for (int i = last; i >= 0; i--)
                {
                  if (table.Rows[last].ItemArray[this.LabelColumnIndex].ToString() == this.LabelColumnText)
                  {
                    table.Rows.RemoveAt(last);
                  }
                }
            }
        
            /// <summary>
            /// Should the grid sort the DataTable DataSource.
            /// </summary>
            /// <param name="table">The DataTable to sort.</param>
            /// <returns>
            /// True if the source, sum column, and sum label info is set for sorting.
            /// False if any one condition fails = sort as normal DataGridView.
            /// </returns>
            private bool ShouldSortTable(DataTable table)
            {
                return table != null && this.LabelColumnIndex >= 0 && this.SumColumnIndices.Count > 0 && !string.IsNullOrEmpty(this.LabelColumnText);
            }
        
            /// <summary>
            /// Sort the DataTable by re-ordering the actual items.
            /// Get the sorted row order. For each sorted row,
            /// remove it from the original list, then re-add it to the end.
            /// </summary>
            /// <param name="table">The DataTable source to sort.</param>
            /// <param name="sort">The "ColumnName ASC/DESC" sort string.</param>
            private void SortRows(DataTable table, string sort)
            {
                DataRow[] sortedRows = table.Select(string.Empty, sort);
        
                foreach (DataRow row in sortedRows)
                {
                    object[] items = (object[])row.ItemArray.Clone();
                    table.Rows.Remove(row);
                    table.Rows.Add(items);
                }
            }
        }
    }
