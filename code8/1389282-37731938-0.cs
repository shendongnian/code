    Database db = this.GetDatabase(databaseName);
    
    List<dynamic> results = new List<dynamic>();
    
    // Run the sql query
    using (DbCommand dbCommand = db.GetSqlStringCommand(query))
    {
    
        foreach (var parameter in inParameters)
        {
            db.AddInParameter(dbCommand, parameter.Key, parameter.Value.Item1, parameter.Value.Item2);
        }
    
        foreach (var parameter in outParameters)
        {
            db.AddOutParameter(dbCommand, parameter.Key, parameter.Value.Item1, parameter.Value.Item2);
        }
    
        using (IDataReader dataReader = db.ExecuteReader(dbCommand))
        {
            IDictionary<string, object> instance;
    
    		while (dataReader.Read())
    		{
    			instance = new ExpandoObject() as IDictionary<string, object>;
    
    			// Populate the object on the fly with the data
    			for (int i = 0; i < dataReader.FieldCount; i++)
    			{
    				instance.Add(dataReader.GetName(i), dataReader[i]);
    			}
    
    			// Add the object to the results list
    			results.Add(instance);
    		}
    		
    		if (dataReader != null)
    		{
    			try
    			{
    				dataReader.Close();
    			}
    			catch { }
    		}			
    	
        }
    
        return results;
    }
