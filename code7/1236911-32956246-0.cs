		void CreateStoredProcedures(string type)
		{
			string spLocation = File.ReadAllText("CreateStoredProcedures.sql");
			using (var conn = new SqlConnection(connectionString + ";database=" + type + DateTime.Now.ToString("yyyyMMdd")))
			{
				try
				{
					Server server = new Server(new ServerConnection(conn));
					server.ConnectionContext.ExecuteNonQuery(spLocation);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			} // End of using, connection will always close when you reach this point.
		}
		bool DetachBackup(string type)
		{
			using (var conn = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(@"sys.sp_detach_db '" + type + DateTime.Now.ToString("yyyyMMdd") + "'", conn);
				try
				{
					conn.Open();
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return false;
				}
			} // End of using, connection will always close when you reach this point.
			return true;
		}
