    List<Item> list= new List<Item>
    {
        new Item(10),
        new Item(10),
        new Item(10),
        new Item(10),
        new Item(10),
        new Item(20),
        new Item(20),
        new Item(20),
    };
    
    Random rnd = new Random();
    foreach (var group in from e in list
                          orderby rnd.NextDouble()
                          group e by e.Distance into g
                          orderby g.Key
                          select g)
    {
        Console.WriteLine("Group with distance {0}", group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("Item Distance={0}, Data={1}", item.Distance, item.Data);
        }
        Console.WriteLine("----");
    }
