	movieBox.Items.Clear();
	try
	{
		db_connection.Open();
		sql_command = new MySqlCommand("select * from mov_db.movies where title like '%" + searchBox.Text + "%'", db_connection);
		sql_reader = sql_command.ExecuteReader();
		if(sql_reader.HasRows)
			while(sql_reader.Read())
			{
				movieBox.Items.Add(sql_reader.GetString("title"));
				movieBox.Items.Add(sql_reader.GetString("year"));
				movieBox.Items.Add(sql_reader.GetString("genre"));
				movieBox.Items.Add(sql_reader.GetString("rating"));
			}
		}
		else
		{
			MessageBox.Show("Sorry, but that title is unavailable.");
		}
	}
