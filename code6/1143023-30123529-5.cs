	string item = comboBox1.Text.ToString();
	string connectionString = "user id=bogdan_db; password=1234;server=localhost; Trusted_Connection=yes; database=cafedrascience; connection timeout=30";
	string sql = @"INSERT INTO coledge_faculty (coledge_id, faculty_id)
					SELECT	c.id, d.id
					FROM	depart AS d
							CROSS JOIN colege AS c
					WHERE	d.Name = @Depart
					AND		c.Name = @Colege;";
	using (var connection = new SqlConnection(connectionString))
	using (var command = new SqlCommand(sql, connection))
	{
		command.Parameters.Add("@Colege", SqlDbType.VarChar, 50).Value = item;
		command.Parameters.Add("@Depart", SqlDbType.VarChar, 50).Value = textBox1.Text;
		connection.Open();
		command.ExecuteNonQuery();
	}
