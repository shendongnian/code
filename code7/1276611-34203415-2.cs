    private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        Color active = Color.LightGreen;
        Color inactive = Color.LightPink;
        DataRowView drv = bindingSource[e.RowIndex] as DataRowView;
        bool isActive = drv.Row.Field<DateTime>("ExpirationDate").Date >= DateTime.Today;
        grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = isActive ? active : inactive;
    }
