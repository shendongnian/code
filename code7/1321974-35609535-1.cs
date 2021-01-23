    private DataTable GetTable(string tableName)
    {
        string queryString = "SELECT * FROM " + tableName;
        DataTable dataTable = new DataTable(tableName);
        using (SqlCommand sqlCommand = new SqlCommand(queryString, _sqlConnection))
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
        {
            _sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            _sqlConnection.Close();
        }
        dataGridViewTable.DataSource = dataTable;
        dataGridViewTable.AutoResizeColumns();
        return dataTable;
    }
