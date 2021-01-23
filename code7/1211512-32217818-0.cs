    ICustomerRepository repository = new CustomerRepository();
            
    //Yields true repository is instance of ICustomerRepository
    Console.WriteLine(typeof(ICustomerRepository).IsInstanceOfType(repository));
    //Yields true repository is instance of CustomerRepository
    Console.WriteLine(typeof(CustomerRepository).IsInstanceOfType(repository));
    CustomerRepository repository2 = new CustomerRepository();
    //Yields true repository2 is instance of ICustomerRepository
    Console.WriteLine(typeof(ICustomerRepository).IsInstanceOfType(repository2));
    //Yields true repository2 is instance of CustomerRepository
    Console.WriteLine(typeof(CustomerRepository).IsInstanceOfType(repository2));
 
