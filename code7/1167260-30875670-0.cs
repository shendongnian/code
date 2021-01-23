	using (SAConnection con = new SAConnection(DBConnStr))
	{
		con.Open();
		try
		{
			string sql = "select * from names where name like ?";
			SACommand cmd = new SACommand(sql, con);
			cmd.Parameters.Add("@p1","Se%");
			SADataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				Console.WriteLine(rdr["name"].ToString());
			}
			rdr.Close();
		}
		finally
		{
			con.Close();
		}
	}
	Console.ReadLine();
