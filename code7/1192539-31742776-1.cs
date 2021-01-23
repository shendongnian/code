    public class YourBulkCopyService : IYourBulkCopyService {
        public void PerformBulkCopy() {
            string sourceCs =  ConfigurationManager.AppSettings["SourceCs"];
            string destinationCs =  ConfigurationManager.AppSettings["DestinationCs"];
            
            // Open a sourceConnection to the AdventureWorks database. 
            using (SqlConnection sourceConnection =
                       new SqlConnection(sourceCs))
            {
                sourceConnection.Open();
                //  Get data from the source table as a SqlDataReader.         
                SqlCommand commandSourceData = new SqlCommand(
                    "SELECT * FROM YourSourceTable", sourceConnection);
                SqlDataReader reader = commandSourceData.ExecuteReader();
                //Set up the bulk copy object inside the transaction.  
                using (SqlConnection destinationConnection =
                           new SqlConnection(destinationCs))
                {
                    destinationConnection.Open();
                    using (SqlTransaction transaction =
                               destinationConnection.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                                   destinationConnection, SqlBulkCopyOptions.KeepIdentity,
                                   transaction))
                        {
                            bulkCopy.BatchSize = 10;
                            bulkCopy.DestinationTableName =
                                "YourDestinationTable";
                            // Write from the source to the destination. 
                            try
                            {
                                bulkCopy.WriteToServer(reader);
                                transaction.Commit();
                            }
                            // If any error, rollback
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                transaction.Rollback();
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }
            }
        }
    }
