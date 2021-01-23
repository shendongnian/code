                using (var bulk = new SqlBulkCopy(transaction.Connection, SqlBulkCopyOptions.Default, transaction))
                {
                    bulk.DestinationTableName = dataTable.TableName;
                    bulk.BulkCopyTimeout = 60 * 15;
                    bulk.BatchSize = 1000;
                    bulk.WriteToServer(dataTable);
                }
