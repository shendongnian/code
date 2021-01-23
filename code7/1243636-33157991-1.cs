    public IEnumerable<Customer> GetCustomers()
    {
        List<Customer> customers = new List<Customer>();
        string sqlQuery = @"SELECT CustName, CustNationality FROM Customer";
        using (var conn = new SqlConnection(connString))        
        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
        {
            conn.Open();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var customer = new Customer {
                    Name = (string)reader["CustName"],
                    Nationality = (string)reader["CustNationality"]
                };
                customers.Add(customer);
            }
        }
        
        return customers;
    }
