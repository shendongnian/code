                    sqlcon.Open();
                    using (SqlBulkCopy sqlBulkCopyVariable= new SqlBulkCopy(sqlcon))
                    {
                        sqlBulkCopyVariable.BulkCopyTimeout = 600; // 10 minutes timeout
                        sqlBulkCopyVariable.DestinationTableName = "targetTableName";
                        sqlBulkCopyVariable.WriteToServer(MyData);
                    }
                    sqlcon.Close();
