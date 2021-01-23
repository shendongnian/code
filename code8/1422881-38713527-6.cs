    public void AddCustomer(string name)
    {
        var customer = new CustomerEntity
        {
            Name = name.ToUpper()
        };
        _context.Customers.Add(customer);
    }
    
