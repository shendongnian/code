    var groupedCustomers = customers.GroupBy(c => c.GetType()).ToList();
    foreach(var customer in groupedCustomers)
    {
       Console.WriteLine(customer.Key.Name + ", count: " + customer.Count());
    }
