    var user = new User();
    user.Id = Guid.NewGuid();
    user.Name = "username";
    
    using (var db = new DbContext())
    {   
        user.Customer = new Customer() { Id = customer.Id };  // only need the id
        db.Customers.Attach(user.Customer);
        db.Users.Add(user);
        db.SaveChanges();
    }
