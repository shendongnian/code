    var results = Tables.GroupBy(t => t.Status)
        .Select(g => new
            {
                Status = g.Key, 
                Count = g.Count()
             });
    foreach(var item in results)
    {
        Console.WriteLine("You have {0} tables of status {1}", item.Count, item.Status);
    }
