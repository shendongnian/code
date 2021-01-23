    MyData data = new MyData();
    
    // 
    // input data ...
    // 
    
    // iteration    
    foreach (var group in from e in data.Persons
                          group e by e.Created.Date into g
                          select g)
    {
        Console.WriteLine("Data entered in day {0}", group.Key.ToShortDateString());
        foreach (var item in group)
        {
            Console.WriteLine(item.Name);
        }
    }
