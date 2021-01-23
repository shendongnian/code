    private void LoginToDB()
    {
        string ServerPath = Server.Text;
        string Database = Schema.Text;
    
        dbStr = "Server=" + ServerPath + ";Database=" + Database + ";Trusted_Connection=True;";
        using (SqlConnection conn = new SqlConnection(dbStr))
        {
            conn.Open();
            conn.Close();
        }
    }
