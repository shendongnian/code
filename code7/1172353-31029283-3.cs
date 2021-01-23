    OracleCommand cmd = new OracleCommand(BuildQuery(all), oracle_connection);
    OracleDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
       client.Index<Record>(new Record(reader.GetSting(0),   
                            reader.GetSting(1), reader.GetSting(2), reader.GetSting(3),    
                            reader.GetSting(4), reader.GetSting(5), reader.GetSting(6),  
                            "index", "type");
    }
    reader.Close();
