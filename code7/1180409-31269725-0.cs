    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
    {
        DataTable dataTable = new DataTable();
        dataTable.RowChanged += changedRow;
        adapter.Fill(dataTable);
        return dataTable;
    }
    void changedRow(object sender, DataRowChangeEventArgs e)
    {
         if(e.Action == DataRowAction.Add)
             e.Row[17] = e.Row[17].ToString().ToUpper();
    }
