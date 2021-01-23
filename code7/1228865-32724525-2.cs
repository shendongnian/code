    var result = list.GroupBy(innerArray => innerArray[0])
        .SelectMany(
            grp => grp.Select(innerArray  => new
                {
                    Values = innerArray, 
                    Count = grp.Count()
                 }));
    foreach(var r in results)
    {
        Console.WriteLine("Values: {0} - Count {1}", string.Join(" ", r.Values), r.Count);
    }
