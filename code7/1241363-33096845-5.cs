    object returnValue = null;
                using (var conn = new System.Data.SqlClient.SqlConnection(AbaseDB.DBFactory.GetInstance().GetConnectionString()))
                {
                    using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("newBehzad", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        conn.Open();
                        command.Parameters.Add("@id", SqlDbType.BigInt).Value = 2;
                        command.Parameters.Add("@ResultValue", SqlDbType.Int).Direction  = ParameterDirection.Output;
    
                        command.ExecuteNonQuery();
    
                        returnValue = command.Parameters["@ResultValue"].Value;
    
                        conn.Close();
                    }
                    if (returnValue != null)
                        MessageBox.Show(returnValue.ToString());
                }
