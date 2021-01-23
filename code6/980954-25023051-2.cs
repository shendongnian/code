    var usersDataReader = _warehouseRepository.GetUserDataReader();
    var connectionString = ConfigurationManager.ConnectionStrings["CorporateWarehouse"].ToString();
    
    using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction | SqlBulkCopyOptions.TableLock))
    {
    	bulkCopy.BatchSize = extractInfo.BatchSize;
    	bulkCopy.BulkCopyTimeout = extractInfo.BatchTimeout;
    	bulkCopy.DestinationTableName = "StagingUserAD";
    
    	try
    	{
    		bulkCopy.WriteToServer(usersDataReader);
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    	finally
    	{
    		usersDataReader.Close();
    	}
    }
