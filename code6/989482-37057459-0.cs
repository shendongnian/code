	public void Schema_Create()
	{
		string sqlConnectionString = "connection string here";
		FileInfo file = new FileInfo(@"filepath to script.sql");
		string script = file.OpenText().ReadToEnd();
		SqlConnection conn = new SqlConnection(sqlConnectionString);
		Server server = new Server(new ServerConnection(conn));
		try
		{
			server.ConnectionContext.ExecuteNonQuery(script);			
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.InnerException.Message);
		}
		file.OpenText().Close();
		conn.Close();
    }
