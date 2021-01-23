    using (var connection = new OracleConnection("connection string"))
   	{
   		connection.Open();
    
   		using (var command = connection.CreateCommand())
   		{
   			command.BindByName = true;
   			command.CommandText = "SELECT get_myTableResult(:p) FROM dual";
    
   			var parameter = command.CreateParameter();
   			parameter.Direction = ParameterDirection.Input;
   			parameter.ParameterName = "p";
   			parameter.Value = "string value";
   			command.Parameters.Add(parameter);
    
   			var = result command.ExecuteScalar();
            // access the data from the result object
   		}
   	}
