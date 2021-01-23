    public void Save(string firstName, string lastName, string streetAddress, string city) 
    { 
        Console.WriteLine("Method Entered @ {0}", DateTime.Now.ToString());
        var customerRepository = new CustomerRepository(); 
        customerRepository.Save(firstName, lastName, streetAddress, city); 
        Console.WriteLine("Method Exited @ {0}", DateTime.Now.ToString());
    }
