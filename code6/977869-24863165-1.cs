    public List<Customer> GetCustomers()
    {
        var customerList = new List<Customer>();
    
        string query = "SELECT Id, " +
                        "[Name] FROM Customers";
    
        string subsetquery = @"select * from Orders where CustomerId = @Id;
                                select * from Returns where CustomerId = @Id";
    
        customerList = _connection.Query<Customer>(query);
    
        foreach (var item in customerList)
        {
            var oPara = new DynamicParameters();
            oPara.Add("@Id", item.Id, dbType: DbType.Int32);
    
            using (var multi = _connection.QueryMultiple(subsetquery, oPara, commandType: CommandType.Text))
            {
                item.orders = multi.Read<Order>();
                item.returns = multi.Read<Return>();
            }
        }
        return customerList;
    }
