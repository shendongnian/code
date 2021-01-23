	using (var command = new SqlCommand(sql, connection))
	{
		var parameter = new SqlParameter("@NickTestType", SqlDbType.Structured);
		parameter.Value = ds.Tables[0];
		parameter.TypeName = "dbo.nicktestTableType";
		command.Parameters.Add(parameter);
		command.ExecuteNonQuery();
	}
