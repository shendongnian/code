      //set up the bulk copy connection
      SqlBulkCopy sbc = new SqlBulkCopy(conn, SqlBulkCopyOptions.TableLock | 
                                              SqlBulkCopyOptions.UseInternalTransaction, null);
      sbc.DestinationTableName = foundTableName;
      sbc.BatchSize = BATCH_SIZE;
      sbc.WriteToServer(rows);
