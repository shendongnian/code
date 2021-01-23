    if (IsDuplicateRowCell((DataGridView)sender, e.RowIndex, e.ColumnIndex, keyNames))
    {
        // Do whatever you like with the cell style 
        e.CellStyle.ForeColor = Color.Red;
        // ...
    }
