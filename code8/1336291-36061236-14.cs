    void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        var cell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        cell.Style.Padding = new Padding(0, 0, 18, 0);
    }
    void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        var cell = grid.Rows[e.RowIndex].Cells[e.RowIndex];
        cell.Style.Padding = new Padding(0, 0, 0, 0);
    }
