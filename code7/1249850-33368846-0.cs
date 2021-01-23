    public DataSet ExecuteQuery()
    {
        ...
            MySqlCommand cmd = new MySqlCommand(this.queryText, conn);
            // parameters are lost!!
            MySqlDataAdapter _mySQLAdapter = new MySqlDataAdapter(cmd);
         ...
    }
