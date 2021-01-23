        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers;
            SqlDataReader sqlDataReader = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllCustomers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        sqlDataReader = cmd.ExecuteReader();
                        customers = (from x in sqlDataReader.Cast<DbDataRecord>()
                                     select new Customer
                                     {
                                         Id = GetValue<long>("Id", x),
                                         ProfileImageId = GetValue<Guid?>("ImageId", x),
                                         ContentType = GetValue<string>("ContentType", x),
                                         FirstName = GetValue<string>("Name", x),
                                         LastName = GetValue<string>("LastName", x),
                                         Email = GetValue<string>("Email", x),
                                         PhoenNumber = GetValue<string>("MobilePhoneNumber",x)
                                        
                                     }).ToList();
                        sqlDataReader.Close();
                    }
                    catch (SqlException ex)
                    {
                        if (sqlDataReader != null) sqlDataReader.Close();
                        cmd.Dispose();
                        throw ex;
                    }
                    finally
                    {
                        if (sqlDataReader != null) sqlDataReader.Dispose();
                        cmd.Dispose();
                    }
                }
            }
            return customers;
        }
