    public IEnumerable<Customer> GetCustomers()
    {
        using (var conn = new SqlConnection(connString))
        {                
            conn.Open();
            return conn.Query<Customer>("SELECT CustName, CustNationality FROM Customer");
        }
    }
