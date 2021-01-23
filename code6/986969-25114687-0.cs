    using(MySqlConnection con1 = new MySqlConnection(connString))
    using(MySqlCommand cmd1 = con.CreateCommand())
    {
       cmd1.CommandType = CommandType.StoredProcedure;
       // Add your parameter values.
       cmd1.ExecuteNonQuery();
       CategID = (int)returnParameter2.Value;
    }
