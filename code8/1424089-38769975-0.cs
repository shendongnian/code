    private DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
    {
        const string TABLE_NAME = "SheetOne";
        
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(new DataTable(TABLE_NAME));
        
        foreach (DataGridViewColumn iColumn in dataGridView.Columns)
        {
            // add only visible columns
            if (iColumn.Visible == true)
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.AllowDBNull = true;
