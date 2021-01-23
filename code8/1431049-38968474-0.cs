    DataTable results = new DataTable();
    
    using(OleDbConnection conn = new OleDbConnection(connString))
    {
        OleDbCommand cmd = new OleDbCommand("Select * from IblInventory", conn);
    
        conn.Open();
    
        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
    
        adapter.Fill(results);
    }
