    private void PopulateNames()
    {
        using (connection = new SqlConnection(connection_string))
        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM namesTable", connection))
        {
            DataTable namesTable = new DataTable();
            adapter.Fill(namesTable);
            Debug.Write(namesTable.AsDataView());
            DataContext = namesTable.AsDataView();
        }
    }
