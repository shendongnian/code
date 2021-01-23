		List<int> tests = new List<int>() { 10, 11, 12};
		var command = new MySqlCommand();
		List<string> parameterNames = new List<string>();
		for (int i = 0; i < tests.Count; i++)
		{
				string parameterName = String.Format("@test{0}", i);
				command.Parameters.AddWithValue(parameterName, tests[i]);
				parameterNames.Add("(" + parameterName + ")");
		}
		string insertSql = @"insert into test(id) values {0}";
		command.CommandText = String.Format(insertSql, String.Join(", ", parameterNames));
		command.Connection = connection;
		int result = command.ExecuteNonQuery();
