    public void WriteData()
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
                {
                    //System.Data.SqlClient.SqlBulkCopyOptions st = new System.Data.SqlClient.SqlBulkCopyOptions();
    
                    //GetBulkCopy(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString, SqlBulkCopyOptions.KeepIdentity)
                    using (System.Data.SqlClient.SqlBulkCopy bulk = new SqlBulkCopy(conn))
                    {
                        conn.Open();
                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(TempTable, conn);
                        cmd.ExecuteNonQuery();
                        
    
                        bulk.DestinationTableName = "#ImportData";
                        for (Int32 I = 0; I < DTFinal.Columns.Count; I++)
                        {
                            bulk.ColumnMappings.Add(DTFinal.Columns[I].ToString(), DTFinal.Columns[I].ToString());
                        }
                        bulk.WriteToServer(DTFinal);
                        cmd = new System.Data.SqlClient.SqlCommand("dbo.SP_AddStudent", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        
                    }
                    //conn.Open();
                    //System.Data.SqlClient.SqlCommand 
    
                    conn.Close();
    
                }
            }
