    var list = new List<string> { "a", "b", "c", "d", "e" };
    var threashold = 2;
    var total = list.Count();
            
    var taken = 0;
    var sublists = new List<List<string>>(); //your final result
    while (taken < total)
    {
        var sublst = list.Skip(taken)
            .Take(taken + threashold > total ? total - taken : threashold)
            .ToList();
        taken += threashold;
        sublists.Add(sublst);
    }
