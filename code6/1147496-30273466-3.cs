    //Create a new client with the BaseUri of the ServiceStack Service
    var client = new JsonServiceClient(BaseUri);
    //GET /customers
    List<Customer> all = client.Get(new GetCustomers()); // =0
    //POST /customers
    var customer = client.Post(new CreateCustomer { Name = "Foo" });
    //GET /customer/1
    customer = client.Get(new GetCustomer { Id = customer.Id });
    //GET /customers
    all = client.Get(new GetCustomers()); //= 1
    //PUT /customers/1
    customer = client.Put(new UpdateCustomer { Id = customer.Id, Name = "Updated Foo" });
    //DELETE /customers/1
    client.Delete(new DeleteCustomer { Id = customer.Id });
    //GET /customers
    all = client.Get(new GetCustomers()); //= 0
