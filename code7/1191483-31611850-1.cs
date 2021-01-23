    public void RunQuery(string query)
    {
        using(OracleConnection conn= new OracleConnection(connString))
        using(OracleCommand cmd = new OracleCommand(query, conn))
        {
            conn.Open();
            //do your data transaction here
         }
    }
