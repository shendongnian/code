	string query = "INSERT INTO dbo.MyTable(Content) VALUES(@Content)";
	using(SqlConnection connection = new SqlConnection(/*yout connection string here*/))
	using(SqlCommand command = new SqlCommand(query, connection))
	{
		connection.Open();
		SqlParameter param = command.Parameters.Add("@Content", SqlDbType.VarBinary);
		param.Value = YourByteArrayVariableHere;
	   
		command.ExecuteNonQuery();  
	}
