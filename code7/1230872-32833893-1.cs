                DatabaseResults results = new DatabaseResults();
                string full_query = "SELECT " + query;
                DbConnection connection = DB.DB().Connection;
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = full_query;
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            results.ColumnNames.Add(reader.GetName(i));
                        }
                        while (reader.Read())
                        {
                            List<string> this_res = new List<string>();
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                this_res.Add(reader[i].ToString());
                            }
                            results.Rows.Add(this_res);
                        }
                    }
                }
                catch (Exception ex)
                {
                    results.ColumnNames.Add("Error");
                    List<string> this_error = new List<string>();
                    this_error.Add(ex.Message);
                    results.Rows.Add(this_error);
                }
                finally
                {
                    connection.Close();
                }
