       [WebMethod]
        public List<Cars> getListOfCars(List<string> aData)
        {
            SqlDataReader dr;
            List<Cars> carList = new List<Cars>();
         
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "YourStoredProcedureName";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string CarServiceId= dr["CarServiceId"].ToString();
                            string CarServiceName= dr["CarServiceName"].ToString();
                            string Contact1= dr["Contact1"].ToString();
         
                            carList.Add(new Cars
                                  {
                                    CarServiceId= CarServiceId,
                                     CarServiceName= CarServiceName,
                                     Contact1= Contact1
                                });
                        }
                    }
                }
            }
            return carList;
        }
