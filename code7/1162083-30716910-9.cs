    var customers = context.Costomers; // this does not populates the result yet
    
    if (!String.IsNullOrEmpty(customerId))
    {
        customers = customers.Where(c => c.CustomerId = customerId); // this does not populates the result yet
    }
    
    if (!String.IsNullOrEmpty(customerName))
    {
        customers = customers.Where(c => c.CustomerName = customerName); // this does not populates the result yet
    }
    
    // finally execute the query
    var custList = customers.ToList();
