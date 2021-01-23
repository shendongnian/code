                using (var tx = conn.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand(aSQL, conn))
                    {
                        command.Connection = conn;
                        command.Transaction = tx;
                        command.Parameters.AddWithValue("@Id", 3);
                        try
                        {
                            command.ExecuteNonQuery();
                            tx.Commit();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
