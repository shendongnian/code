    private void DGVParent_CellMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex < 0)
            return;
        if (DGVChild.Columns.Count != DGVParent.Columns.Count)
        {
            DGVChild.Columns.Clear();
            foreach (var parentColumn in DGVParent.Columns)
            {
                DGVChild.Columns.Add((DataGridViewColumn)parentColumn.Clone());
            }
        }
        var parentRow = DGVParent.Rows[iCnt];
        var childRow = (DataGridViewRow)parentRow.Clone();
        int iColIndex = 0;
        foreach (DataGridViewCell cell in parentRow.Cells)
        {
            row.Cells[iColIndex++].Value = cell.Value;
        }
        DGVChild.Rows.Add(childRow);
        DGVChild.Focus();  // SET FOCUS ON THE CHILD.
    }
