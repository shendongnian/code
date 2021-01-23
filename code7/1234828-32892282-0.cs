    public bool UploadBulkData(List<CustomerDTO> bulkData)
		{
			bool returnValue = false;
			try
			{
				string query = @"insert into PCMS.Customer ( surname, firstName, emailAddress) values 
								(:surname, :firstName, :emailAddress)";
				oracleConnection.Open();
				using (var command = oracleConnection.CreateCommand())
				{
					command.CommandText = query;
					command.CommandType = CommandType.Text;
					command.BindByName = true;
				  // In order to use ArrayBinding, the ArrayBindCount property
				  // of OracleCommand object must be set to the number of records to be inserted
					command.ArrayBindCount = bulkData.Count;
					command.Parameters.Add(":surname", OracleDbType.Varchar2, bulkData.Select(c => c.Surname).ToArray(), ParameterDirection.Input);
					command.Parameters.Add(":firstName", OracleDbType.Varchar2, bulkData.Select(c => c.FirstName).ToArray(), ParameterDirection.Input);
					command.Parameters.Add(":emailAddress", OracleDbType.Varchar2, bulkData.Select(c => c.EmailAddress).ToArray(), ParameterDirection.Input);
					int result = command.ExecuteNonQuery();
					**result is what you need**
				}
			}
			catch (OracleException ex)
			{
				//Log error thrown
			}
			finally
			{
				oracleConnection.Close();
			}
			return returnValue;
		}
