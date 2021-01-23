    public bool LoginData(LoginEntity elOj)
    {
        try
        {
			con = new SqlConnection(constr);
			int result;
			if(ConnectionState.Closed==con.State)
				con.Open();
			SqlCommand cmd = new SqlCommand("uspuserlogin", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Username", elOj.Username);
			cmd.Parameters.AddWithValue("@Password", elOj.Password);
            var obj = cmd.ExecuteScalar();
            return ((int)obj > 0);
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			con.Close();
		}
    }
    
    
