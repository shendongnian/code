    string sql = "UPDATE tbSystems SET Systems = @Systems WHERE id = @id";
    SqlConnection connection = new SqlConnection("your connection string");
    SqlCommand command = new SqlCommand(sql, connection);
    
    SqlParameter param = new SqlParameter();
	             param.ParameterName = "@Systems";
		         param.Value         = systems;
    command.Parameters.Add(param);
    SqlParameter paramId  = new SqlParameter();
	             paramId.ParameterName = "@id";
		         paramId.Value         = Id;
    command.Parameters.Add(paramId);
 
