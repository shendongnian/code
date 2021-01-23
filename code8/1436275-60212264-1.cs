                using (var bulk = new SqlBulkCopy(transaction.Connection, SqlBulkCopyOptions.Default, transaction))
                {
                    bulk.DestinationTableName = dataTable.TableName;
                    bulk.BatchSize = 1000;
                    bulk.WriteToServer(dataTable);
                }
