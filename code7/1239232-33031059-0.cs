	using (var conn = new SqlConnection(connectionString))
	{
		conn.Open();
		using (var comm = new SqlCommand(queryString, conn)
		{
			using (var ms = new MemoryStream((byte[])comm.ExecuteScalar()))
			{
				pictureBox1.Image = Image.FromStream(ms);
			}
		}
	}
