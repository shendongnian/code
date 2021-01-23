    var result = list.GroupBy(l => l[0])
        .SelectMany(
            grp => grp.Select(l => new
                {
                    Values = l, 
                    Count = grp.Count()
                 }));
    foreach(var r in results)
    {
        Console.WriteLine("Values: {0} - Count {1}", string.Join(" ", r.Values), r.Count);
    }
