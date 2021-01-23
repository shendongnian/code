    var customerList = new List<Customer>();
    for (int i = 0; i < 99; i++)
    {
       Customer newPerson = new Customer();
       customerList.Add(newPerson);
    }
    // Find the customer in the list with id 53
    var customer53 = customerList.First(x => x.id == 53);
    // Change its name
    customer53.name = "John Doe";
    // And print it
    customer53.print(); 
