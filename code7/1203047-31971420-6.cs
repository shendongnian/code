    // Insert customers to the cache            
    var customers = new RedisDictionary<int, Customer>("customers");
    customers.Add(100, new Customer() { Id = 100, Name = "John" });
    customers.Add(200, new Customer() { Id = 200, Name = "Peter" });
    // Or if you have a list of customers retrieved from DB:
    IList<Customer> customerListFromDb;
    customers.AddMultiple(customerListFromDb.ToDictionary(k => k.Id));
    // Query a customer by its id
    var customers = new RedisDictionary<int, Customer>("customers");
    Customer customer100 = customers[100];
