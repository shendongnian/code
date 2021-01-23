    var result = 
        one.Select(a => Tuple.Create(a, "one")) // tag list one items
        .Concat(two.Select(a => Tuple.Create(a, "two"))) // tag list two items
        .GroupBy(t => t.Item1.Name) // group items by Name
        .ToList(); // cache result
    var list_one_only = result.Where(g => g.Count() == 1 && g.First().Item2 == "one");
    var list_two_only = result.Where(g => g.Count() == 1 && g.First().Item2 == "two");
    var both_list_diff = result.Where(g => g.Count() == 2 && g.First().Item1.Age != g.Skip(1).First().Item1.Age);
