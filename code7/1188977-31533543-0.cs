    List<int> ids = new List<int>();
    using (SqlCommand command = new SqlCommand(@"declare @T TABLE(Id int)
                                                                    INSERT INTO YourTableName(YourTableColumnNames)
                                                                    OUTPUT Inserted.Id into @T VALUES 
                                                                    (YourValues1),
                                                                    (YourValues2),
                                                                    (YourValues3),
                                                                    (etc...) select Id from @T ", con))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = int.Parse(reader[0].ToString());
                                    ids.Add(id);
                                }
                            }
                        }
