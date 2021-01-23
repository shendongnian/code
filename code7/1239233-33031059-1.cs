	using (var conn = new SqlConnection(connectionString))
	{
		conn.Open();
		using (var comm = new SqlCommand(queryString, conn)
		{
			using (var reader = new comm.ExecuteReader())
			{
				if (reader.Read())
				{
					using (var ms = new MemoryStream((byte[])reader["Column"]))
					{
						pictureBox1.Image = Image.FromStream(ms);
					}
				}
			}
		}
	}
