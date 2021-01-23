    var groupedCustomers = customers.GroupBy(c => c.GetType()).ToList();
    foreach(var type in groupedCustomers)
    {
       Console.WriteLine(type.Key.Name + ", count: " + type.Count());
    }
