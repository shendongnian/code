        var transportId = 5;
        var res = from s in _context.Stores
                    let Type = _context.Stores.Take(1).Select(x => s.Type1).Cast<int>().FirstOrDefault()
                    group Type by Type into pt1
                    select new TypeTransportation
                    {
                        Type = pt1.Key, // Needs to be int
                        Count = _context.Products.Where(i => i.transportId == transportId && i.Type == pt1.Key).Count()
                    };            
        foreach (var item in res)
        {
            Console.WriteLine(item.Type + " " + item.Count);
        }
        Console.ReadKey();
