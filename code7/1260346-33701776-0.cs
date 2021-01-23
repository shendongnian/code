    using (var command = DbProviderFactories.GetFactory(provider).CreateCommand()) // here you've created the command
                {
                    if (command == null) return null;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Continent";
                    using (var reader = command.ExecuteReader()) //Here you're reading what the command returned.
                        while (reader.Read())
                            continents.Add(new Continent(reader["Code"].ToString(), reader["EnglishName"].ToString()));
                }
