    public List<T> GetAll(string sql)
    {
        var list = new List<T>();
        SqlDatabase db = null;
        SqlCommand cmd = null;
        IDataReader reader = null;
        try
        {                    
			db = new SqlDatabase(Registry.Instance.CurrentConnectionString);
			cmd = new SqlCommand(sql);
			
            reader = db.ExecuteReader(cmd);
			
			while (reader.Read())
			{
                list.Add(GetMethod(reader));
			}
		}
		catch (SqlException ex)
		{
			// Deal with sql exceptions
			ShowExceptionError(ex);
			return list;
		}
		catch (Exception ex)
		{
			// Deal with all other exceptions
            ShowExceptionError(ex);
			return list;
		}
        finally
		{
			if (db != null)
			{
				db.Dispose();
			}
			
			if (cmd != null)
			{
				cmd.Dispose();
			}
			
			if (reader != null)
			{
				reader.Dispose();
			}
		}
        return list;
    }
