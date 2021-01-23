         DbSet<Survey> AllSurveys =new DbSet<Survey>();
         using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Survey srv=new Survey
                                 {
                                  Id = int.Parse(dataReader[0].ToStrig()),
                                  Title = dataReader[1].ToString()   
                                  };
                               AllSurveys .Add(srv);
                            }
                        }
