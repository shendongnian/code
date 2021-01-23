    using (SqlCommand command = new SqlCommand(q, connection))
                        {
                            cmd.CommandTimeout = 60;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        dataList .Add(reader.GetString(0));
                                    }
                                }
                            }
                        }
