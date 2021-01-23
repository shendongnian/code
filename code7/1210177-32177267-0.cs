    IEnumerable<Customer> items = new Customer[]
    {
        new Customer {Name = "test1", Id = 999},
        new Customer {Name = "test2", Id = 989}
    };
    var lookup = items.ToDictionary(itemKeySelector => itemKeySelector.Id);
    var result = lookup[989];
    Console.WriteLine(result.Name); // Prints "test2".
