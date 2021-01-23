    using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand
                       ("SELECT TOP 10 Column1, Column2 FROM Table1; SELECT TOP 10 Column1, Column2 FROM Table2", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        bool haveresult = true;
                            while (haveresult)
                            {
                                DataTable tempTable = new DataTable();
                                tempTable.Load(reader);
                                dataTables.Add(tempTable);
                                try
                                {
                                    reader.Read();
                                }
                                catch
                                {
                                    haveresult = false;
                                }
                                
                            }
                            
                        }
                    
                }
            }
