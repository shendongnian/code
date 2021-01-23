    dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    if (dgv.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    if (e.ColumnIndex == newSortColumn )
                    {
                        if (newColumnDirection == ListSortDirection.Ascending)
                            newColumnDirection = ListSortDirection.Descending;
                        else
                            newColumnDirection = ListSortDirection.Ascending;
                    }
    
                    newSortColumn = e.ColumnIndex;
    
                    switch (newColumnDirection)
                    {
                        case ListSortDirection.Ascending:
                            dgv.Sort(dgv.Columns[newSortColumn], ListSortDirection.Ascending);
                            break;
                        case ListSortDirection.Descending:
                            dgv.Sort(dgv.Columns[newSortColumn], ListSortDirection.Descending);
                            break;
                    }
                }
    }
