    string groupby = "Type1";
    List<Dictionary<string, List<string>>> result =
        ListdicA.Concat(ListdicB).GroupBy(x => x[groupby]).Select(x =>
            x.SelectMany(y => y) // Put .Distinct() here to remove duplicates.(optional)
                .GroupBy(y => y.Key).Select(y => new KeyValuePair<string, List<string>>(y.Key, y.Select(z => z.Value).ToList())))
                    .Select(x => x.ToDictionary(y => y.Key, y => y.Value)).ToList();
    foreach (var d in result)
    {
        foreach (var k in d)
        {
            Console.Write(k.Key + " : ");
            foreach (var l in k.Value)
            {
                Console.Write(l + " ");
            }
            Console.WriteLine();
        }
    }
