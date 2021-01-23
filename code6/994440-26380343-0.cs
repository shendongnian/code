    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SomeConnectionString"].ConnectionString))
        {
             connection.Open();
             SqlTransaction transaction = connection.BeginTransaction();
     
             using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
             {
                bulkCopy.BatchSize = 100;
                bulkCopy.DestinationTableName = "dbo.Person";
                try
                {
                    bulkCopy.WriteToServer(listPerson.AsDataTable());
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    connection.Close();
                }
              }
     
              transaction.Commit();
        }
