      List<Ekipa> result = new List<Ekipa>();
            DataSet ds = new DataSet();
            using (UsersContext uc = new UsersContext())
            {
                using (SqlConnection con = new SqlConnection(uc.Database.Connection.ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("procedurename", con);
                    com.CommandType = CommandType.StoredProcedure;
                     command.Parameters.AddWithValue("@id", 12);
                    using (SqlDataAdapter da = new SqlDataAdapter(com))
                    {
                        da.Fill(ds);
                    }
                }
            }
            result = (from myRow in ds.Tables[0].AsEnumerable()
                      select new Ekipa()
                      {
                          UserId = myRow.Field<int>("UserId"),
                          UserName = myRow.Field<string>("UserName"),
                          Bodovi = myRow.Field<int>("Bod"),
                          OU = myRow.Field<int>("OU"),
                          Gol = myRow.Field<int>("PostignutiGolovi"),
                      }).ToList();
