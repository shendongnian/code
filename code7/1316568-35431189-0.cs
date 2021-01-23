    var result = lst.GroupBy(n => n.Id);
    
    foreach (var g in result)
    {
        Console.WriteLine("For group {0} the total is {1}.", g.Key, g.Count());
        foreach(var item in g)
        {
            Console.WriteLine("Name: {0}", item.Name);
        }
    }
