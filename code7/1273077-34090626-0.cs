    var listA = new List<double> { 1.0, 2.0, 3.0 };
    var listB = new List<double> { 1.1, 2.1, 3.1 };
    var listC = new List<double> { 1.2, 2.2, 3.2 };
    var listD = new List<double> { 1.3, 2.3, 3.3 };
    
    var items = new List<Tuple<double, double, double, double>>();
    for (var i = 0; i < listA.Count; ++i)
        items.Add(Tuple.Create(listA[i], listB[i], listC[i], listD[i]));
    
    var sorted = items.OrderBy(x => x.Item1);
    listA = sorted.Select(x => x.Item1).ToList();
    listB = sorted.Select(x => x.Item2).ToList();
    listC = sorted.Select(x => x.Item3).ToList();
    listD = sorted.Select(x => x.Item4).ToList();
