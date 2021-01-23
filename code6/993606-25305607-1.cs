    // Create container ready for the resultsets
    var result = new RefererStatisticResult();
    using (var myContext = new MyContext())
    {
        // Create command from the context in order to execute
        // the `GetReferrer` proc
        var command = myContext.Database.Connection.CreateCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "[dbo].[GetReferrer]";
        // add in command parameters
        // (not shown)
    
        try
        {
            myContext.Connection.Open();
            var reader = command.ExecuteReader();
     
            // Drop down to the wrapped `ObjectContext` to get access to
            // the `Translate` method
            var objectContext = ((IObjectContextAdapter)myContext).ObjectContext;
    
            // Read Entity1 from the first resultset
            result.Set1 = objectContext.Translate<Entity1>(reader, "Set1", MergeOptions.AppendOnly);
    
            // Read Entity2 from the second resultset
            reader.NextResult();
            result.Set2 = objectContext.Translate<Entity2>(reader, "Set2", MergeOptions.AppendOnly);        
        }
        finally
        {
            myContext.Database.Connection.Close();
        }
    }
