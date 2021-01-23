      public DbSet<Survey> GetAllSurveys ( )
        {
            using (SqlCommand cmd = new SqlCommand("GetAllSurveys", this._Conn)
            {
               cmd.CommandType = CommandType.StoredProcedure;
               this._Conn.Open();
               DbSet<Survey> AllSurveys = new DbSet<Survey>();
               using (SqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    Survey srv=new Survey {
                                      Id = dataReader.IsDBNull(0)?Default(int): dataReader.GetInt32(0),
                                      Title =dataReader.IsDBNull(1)?String.Empty: dataReader.GetString(1)};
                                    AllSurveys.Add(srv);
                                }
                            }
               this._Conn.Close();
               return AllSurveys;
        }
    }
        
