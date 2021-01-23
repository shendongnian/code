     DataTable dt = getData();
     SqlBulkCopyOptions options = SqlBulkCopyOptions.Default;
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlconnection, options, null))
                        {
                            dt.Columns.Add("Id", typeof(long)).SetOrdinal(0);
                            dt = AddDefaultColumn(dt);
                            sqlBulkCopy.BulkCopyTimeout = 300;
                            sqlBulkCopy.DestinationTableName = "tableName";
                            sqlBulkCopy.WriteToServer(dt);
                        }
