    List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    var result =
        list.Select((v, i) => new { Value = v, Index = i })
            .GroupBy(x => x.Index % 6)
            .Select(grp => grp.Select(x => x.Value).ToList())
            .ToList();
    int groupNumber = 1;
    foreach (var l in result)
    {
        Console.WriteLine("Group {0} : {1}", groupNumber++, string.Join(", ", l));
    }
