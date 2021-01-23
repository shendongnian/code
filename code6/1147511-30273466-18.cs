    var client = new JsonServiceClient(BaseUri);
    
    //GET /customers
    var all = client.Get(new GetCustomers());                         // Count = 0
    
    //POST /customers
    var customer = client.Post(new CreateCustomer { Name = "Foo" });
    
    //GET /customer/1
    customer = client.Get(new GetCustomer { Id = customer.Id });      // Name = Foo
    
    //GET /customers
    all = client.Get(new GetCustomers());                             // Count = 1
    
    //PUT /customers/1
    customer = client.Put(
        new UpdateCustomer { Id = customer.Id, Name = "Bar" });       // Name = Bar
    
    //DELETE /customers/1
    client.Delete(new DeleteCustomer { Id = customer.Id });
    
    //GET /customers
    all = client.Get(new GetCustomers());                             // Count = 0
