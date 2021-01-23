    using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var comm = new SqlCommand(command, conn))
                {
                    using (var reader = comm.ExecuteReader())
                    {
                           Customers= reader.Cast<IDataRecord>().Select(x=>
                            new Customer
                            {
                                ID = (int)x["ID"],
                                name = x["name"].ToString(),
                                 
                            }).ToList();
                    }
                }
            }
    var json = JsonConvert.SerializeObject(Customers);
