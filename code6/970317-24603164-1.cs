    var lists = sourceItems.Aggregate(Tuple.Create(new List<Foo>(), new List<Foo>()), (acc, foo) =>
    {
        if (foo.IsSelected)
        {
            acc.Item1.AddRange(acc.Item2);
            acc.Item2.Clear();
            acc.Item2.Add(foo);
        }
        else if (acc.Item2.Any())
        {
            acc.Item2.Add(foo);
        }
        return acc;
    });
    
    if (lists.Item2.Any()) lists.Item1.Add(lists.Item2.First());
