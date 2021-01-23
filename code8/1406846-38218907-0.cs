	public void DumpTableToFile(SqlConnection connection, string tableName, string destinationFile)
	{
		try
		{
			using(var transaction = new TransactionScope())
			{
				// Select all non-processed records.
				using (var command = new SqlCommand("select LineType,CustomerFirstName AS 'Forename' ,CustomerLastName,Age,dob as 'Date of Birth',maritalStatus AS 'Marital Status',homePhone AS 'Home', mobileNumber AS Mobile,emailAddress AS Email,Address1 + Address2  + PostCode AS 'Address' ,employmentStatus AS Employment,occupation AS Occupation,propertyValue AS 'Property Value',mortgageBalance AS 'Mortgage Balance',balanceOnSecuredDebt AS 'Balance on secured Debt',mortgageType as 'Mortgage Type' from " + tableName 
					+ " WHERE NOT isProcessed", connection))
				using(var reader = command.ExecuteReader())
				using(var outFile = File.CreateText(destinationFile))
				{
					string[] columnNames = GetColumnNames(reader).ToArray();
					int numFields = columnNames.Length;
					outFile.WriteLine(string.Join(",", columnNames));
					if (reader.HasRows)
					{
						while(reader.Read())
						{
							string[] columnValues =
								Enumerable.Range(0, numFields)
									.Select(i => reader.GetValue(i).ToString())
									.Select(field => string.Concat("\"", field.Replace("\"", "\"\""), "\""))
									.ToArray();
							outFile.WriteLine(string.Join(",", columnValues));
						}
					}
				}
				// Update the same records that were just exported.
				using (var command = new SqlCommand("UPDATE " + tableName + " SET isProcessed=true WHERE NOT isProcessed", connection))
					command.ExecuteNonQuery();
				transaction.Complete();
			}
		}
		catch
		{
			// If something went wrong, delete the export file.
			File.Delete(destinationFile);
			throw;
		}
	}
