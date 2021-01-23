	private DataTable GetTableN(string sql, string[] pars, DbCommand zapytanie, DbDataAdapter da)
	{	
		DataSet ds = new DataSet();
		try
		{
			if (pars != null)
			{
				for (int i = 0; i < pars.Length; i++)
				{
					zapytanie.Parameters.AddWithValue("@param" + i, pars[i]);
				}
			}
			connn.Open();
			da.SelectCommand = zapytanie;
			da.Fill(ds);
			return ds.Tables[0];
		}
		catch (DbException e)
		{
			throw (new SqlException(e.Message.ToString()));
		}
		finally
		{
			connn.Close();
			zapytanie.Dispose();
			da.Dispose();
			ds.Dispose();
		}
	}
