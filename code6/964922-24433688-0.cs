	var table = new DataTable();
	table.Columns.Add("Value", typeof(int));
	for (int i = 0; i < liste.Count; i++)
	{
		var row = table.NewRow();
		row[0] = liste[i];
		table.Rows.Add(row);
	}
	string sql = "SELECT ID FROM [User] WHERE ID IN (SELECT Value FROM @Liste)";
	using (var connection = new SqlConnection("Your connection String"))
	using (var command = new SqlCommand(sql, connection))
	{
		connection.Open();
		var tvp = new SqlParameter("@Liste", SqlDbType.Structured).TypeName = "ListOfInt";
        tvp.Value = table;
		command.Parameters.Add(tvp);
		using (var reader = command.ExecuteReader())
		while (reader.Read())
		{
			outliste.Add(reader.GetInt("ID"));
		}
	}
