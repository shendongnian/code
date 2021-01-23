      public DbSet<Survey> GetAllSurveys ( )
        {
            using (SqlCommand command = new SqlCommand("GetAllSurveys", this._Conn)
            {
               cmd.CommandType = CommandType.StoredProcedure;
               this._Conn.Open();
               DbSet<Survey> AllSurveys = new DbSet<Survey>();
               using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    Survey srv=new Survey {
                                      Id = int.Parse(dataReader[0].ToString()),
                                      Title = dataReader[1].ToString()};
                                    AllSurveys.Add(srv);
                                }
                            }
               this._Conn.Close();
               return AllSurveys;
        }
    }
        
