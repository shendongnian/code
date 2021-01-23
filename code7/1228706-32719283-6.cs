    Customer c = new Customer
    {
        ...
        Address = new Address { AddressType = 1 }
    };
    
    context.Customer.Add(c);
    context.SaveChanges();
