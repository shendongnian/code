    static IEnumerable<QueryResult> GetData(SqlCommand command)
    {
    	using (var reader = command.ExecuteReader())
    	{
    		int index = 0;
    		do
    		{
    			while (reader.Read())
    			{
    				IDictionary<string, object> expando = new ExpandoObject();
    				for (int i = 0; i < reader.FieldCount; i++)
    					expando.Add(reader.GetName(i), reader.GetValue(i));
    				yield return new QueryResult(index, expando);
    			}
    			index++;
    		}
    		while (reader.NextResult());
    	}
    }
