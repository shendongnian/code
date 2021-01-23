                    string cmdString = "select m_id from table_1");
                    SqlCommand command = new SqlCommand(cmdString, conn);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var m_Id = reader["m_id"];
                            if (macId != DBNull.Value)
                            {
                                cmdString = 
                                "update table_1 set last_status_update = GETUTCDATE() where [m_id] % 2 != 0 AND [m_id] ='" + m_Id + "';"
                               
                                command = new SqlCommand(cmdString, conn);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
