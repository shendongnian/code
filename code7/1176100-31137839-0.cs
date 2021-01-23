    using (var objCommand = new SqlCommand("SpName", objConnection))
                        {
                            objCommand.Parameters.AddWithValue("@Param1", Param);
                            objCommand.Parameters.AddWithValue("@Purpose", Purpose);
                            objConnection.Open();
                            objCommand.CommandType = CommandType.StoredProcedure;
                            using (var reader = objCommand.ExecuteReader())
                            {
    
                                    while (reader.Read())
                                    {
    
                                        objemailsend.Name = Convert.ToString(reader[1]);
                                    }
    
                            }
                        }
    
             objConnection.Close();
