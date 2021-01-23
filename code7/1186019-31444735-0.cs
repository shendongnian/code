	public void GetInformationDataReader(string procName, SqlParameter[] parameters, Action<SqlDataReader> processRow)
	{
		SqlDataReader reader = null;
		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			conn.Open();
			using (SqlCommand cmd = new SqlCommand(procName, conn))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				if (parameters != null)
				{
					foreach(SqlParameter parameter in parameters)
					{
						cmd.Parameters.Add(parameter);
					}
				}
				using (SqlDataReader dataReader = cmd.ExecuteReader())
				{
					while (dataReader.Read())
					{
						// call delegate here.
						processRow(dataReader);
					}
				}
			}
		}
		return reader;
	}
	public ModelContexts.InformationContext GetInformation(string username)
	{
		SqlDataReader reader = null;
		ModelContexts.InformationContext context = new ModelContexts.InformationContext();
		SqlParameter[] parameters =
		{
			new SqlParameter("@Username", SqlDbType.NVarChar, 50)
		};
		parameters[0].Value = username;
		try
		{
			// Instead of returning a reader, pass in a delegate that will perform the work
			// on the data reader at the right time, and while the connection is still open.
			DatabaseManager.Instance.GetInformationDataReader(
				"GetInformation",
				parameters,
				reader => {
					context.FirstName = reader["FirstName"].ToString();
					context.LastName = reader["LastName"].ToString();
					context.Email = reader["Email"].ToString();
				});
		}
		catch(Exception ex)
		{
			throw new ArgumentException(ex.Message);
		}
		return context;
	}
