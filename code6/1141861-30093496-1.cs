	private Boolean updateData(OleDbCommand cmd)
	{
		string strConString = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;
		OleDbConnection conn = new OleDbConnection(strConString);
		cmd.CommandType = CommandType.Text;
		cmd.Connection = con;
		try
		{
			con.Open();
			cmd.ExecuteNonQuery();
			return true;
		}
		catch (Exception ex)
		{
			Response.Write(ex.Message);
			return false;
		}
		finally
		{
			con.Close();
			con.Dispose();
		}
	}
