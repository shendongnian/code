	public XmlDocument GetPunchListXml(string communityDesc)
	{
		// 1. Use a new SqlConnection everywhere and do not register SqlConnection as a field on the class.
		// This is a Microsoft recommended best practice. Sql Server handles connection pooling so the call new SqlConnection is very cheap.
		// 2. a using block will close and dispose the connection for you
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			connection.Open();
			using (SqlCommand command = new SqlCommand("GetPunchList", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				SqlParameter parameter1 = new SqlParameter("@communityDesc", SqlDbType.VarChar);
				parameter1.Value = communityDesc;
				parameter1.Direction = ParameterDirection.Input;
				command.Parameters.Add(parameter1);
				// wrap your DataReader in a using block
				using (var reader = command.ExecuteXmlReader())
				{
					var doc = new XmlDocument();
					if (reader.Read())
					{
					   doc.Load(reader);
					}
					return doc;
				}
			}
		}
	}
	
