        private static bool UploadDataSet(DataSet ds)
        {
            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(AzureSqlConnection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                bulkCopy.DestinationTableName = ds.Tables[0].TableName;
                bulkCopy.WriteToServer(ds.Tables[0]);
                Log.LogWriter(string.Format("Updating data in table {0}", ds.Tables[0].TableName), "Success");
                return true;
            }
            catch (Exception ex)
            {
                Log.LogWriter(string.Format("Failed to update table {0}. Error {1}", ds.Tables[0].TableName, ex), "Failed");
                throw;
            }
        }
