    using (SqlCommand command = new SqlCommand(q, connection))
                        {
                            command.CommandTimeout = 180;
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
