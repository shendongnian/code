		List<ObjectToStoreInOracle> items = new List<ObjectToStoreInOracle>();
		using (SqlCommand cmdAddNewObject = new SqlCommand("SelectNewObjects", con))
		{
			cmdAddNewObject.CommandType = CommandType.StoredProcedure;
			cmdAddNewObject.Parameters.AddWithValue("@parameter1", parameter1);
			using (SqlDataReader rdrAddNewObject = cmdAddNewObject.ExecuteReader())
			{
				while (rdrAddNewObject.Read())
				{
					if (rdrAddNewObject.GetString(0) != null)
					{
						try
						{
							// add items to temp array list
							items.Add(new ObjectToStoreInOracle(parameter1, rdrAddNewObject.GetString(0), rdrAddNewObject.GetString(0).Length / 4, rdrAddNewObject.GetString(0).Substring(0, 2), rdrAddNewObject.GetString(0).Substring(2, 2), rdrAddNewObject.GetString(1))))	
							
							if (rdrAddNewObject.GetString(1) == "No description found")
							{
								// Do something
							}
							else
							{
								// Do something else
							}
						}
						catch (Exception ex)
						{
							// Throw exception
						}
					}
				}
			}
		}
		AddToOracleDB(items)
		private void AddToOracleDB(List<ObjectToStoreInOracle> items){
		//do stuff here to add to the Oracle DB
		}
