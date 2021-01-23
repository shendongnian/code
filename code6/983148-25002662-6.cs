    var list = new [] { 1, 3, 15, 16, 4, 27, 65, 2, 1, 99, 3, 16, 21, 72, 1, 5, 7, 4, 2, 8 };
    var search = new [] { 1, 2, 3, 4 };
    
    var matches = list
        .Select((v,i) => new { Value=v, Index=i })
        .Where(n => search.Contains(n.Value))
        .ToList()
        ;
    
    for (var start=0; start < matches.Count(); start++) {
        var group = new List<int>();
        group.Add(matches[start].Value);
        foreach (var match in matches.Skip(start)) {
            if (!group.Contains(match.Value)) {
                group.Add(match.Value);
            }
            if (group.Count == search.Length) {
                Console.WriteLine(matches[start].Index+" - "+match.Index);
                break;
            }
        }
    }
