    var result = lst.GroupBy(n => n.Id)
                    .Select(c => new { Key = c.Key, total = c.Count(), Items = c});
    foreach(var r in result)
    {
        Console.WriteLine("Key: {0} Count:{1}",r.Key,r.total)
        foreach(var i in r.Items)
            Console.WriteLine(i.Name);
    }
