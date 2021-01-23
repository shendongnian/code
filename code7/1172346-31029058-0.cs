    OracleCommand cmd = new OracleCommand("SELECT ... FROM TableName", oracle_connection);
    int batchSize = 500;    
    using (OracleDataReader reader = cmd.ExecuteReader())
    {
    	List<Record> l = new List<Record>(batchSize);
    	string[] str = new string[7];
    	int currentRow = 0;
    
    	while (reader.Read())
    	{
    		for (int i = 0; i < 7; i++)
    		{
    			str[i] = reader[i].ToString();
    		}
    
    		l.Add(new Record(str[0], str[1], str[2], str[3], str[4], str[5], str[6]));
    		
            // Commit every time batchSize records have been read
    		if (++currentRow == batchSize)
    		{
    			foreach(Record r in l)
    			{
    				client.Index<Record>(r, "index", "type");
    			}
    			l.Clear();
    			currentRow = 0;
    		}
    	}
        // commit remaining records
        foreach(Record r in l)
    	{
    		client.Index<Record>(r, "index", "type");
    	}
    }
