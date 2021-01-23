    private void datagridview.CellContentClick(object sender, Datagridviewcelleventargs e)
    {
        If(e.RowIndex < 0 || e.ColumnIndex < 0)
            return;
        string columnName = this.YourDataGridView.Columns[e.ColumnIndex].Name;
        if (columnName.Equals("myDatagridviewEditColumn") == true)
        {
            //code for EDIT
        }
        if (columnName.Equals("myDatagridviewDeleteColumn") == true)
        {
            //code for DELETE
        }
    }
