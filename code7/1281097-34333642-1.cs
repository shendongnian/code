    using (var db = new Context())
    {
        var customer = new Customer();
        // Here customer.CustomerID is empty     
        db.Customers.Add(customer);
        db.SaveChanges();
        // Here customer.CustomerID is assigned
    }
