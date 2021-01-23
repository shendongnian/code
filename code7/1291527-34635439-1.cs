     protected DataTable QueryExec(string Query,DataTable Table, bool append = false) {
        if (!append)
            Table = new DataTable();
        SqlConnection Connector = new SqlConnection(/*connection data here*/);
        SqlCommand Command = new SqlCommand(Query, Connector);
        Connector.Open();
        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
        Adapter.Fill(Table);
        Connector.Close();
        return Table;
    }
