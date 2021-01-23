    public IEnumerable<Customer> GetCustomers()
    {
        string sqlQuery = @"SELECT CustName, CustNationality FROM Customer";
        using (var conn = new SqlConnection(connString))        
        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
        {
            conn.Open();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                yield return new Customer {
                    Name = (string)reader["CustName"],
                    Nationality = (string)reader["CustNationality"]
                };
            }
        }
    }
