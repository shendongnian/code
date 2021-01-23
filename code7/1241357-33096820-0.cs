    using (var conn = new SqlConnection(connectionString))
                using (var command = new SqlCommand("newBehzad", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add("@id", SqlDbType.BigInt).Value = 2;
                   // command.Parameters.Add("@ResultValue", SqlDbType.Int); Comment this line
    
    
                    SqlParameter retval = command.Parameters.Add("@ResultValue", SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;
    
                    retunvalue = (string)command.Parameters["@ResultValue"].Value;
    
                    //SqlParameter retval = sqlcomm.Parameters.Add("@b", SqlDbType.VarChar);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show(returnValue);
