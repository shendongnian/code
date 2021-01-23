    Dictionary<string, string> values = new Dictionary<string, string>
    {
        { "abc","Message 1" },
        { "def","Message 1" },
        { "ghi","Message 2"},
        { "jkl","Message 1"},
        { "mno","Message 2"},
        { "pqr","Message 3"}
    };
    var result = values.GroupBy(x => x.Value)
                       // In this line the g.Key refers to the `Key` of the IGrouping and not
                       // of the original dictionary. 
                       .ToDictionary(g => g.Key ?? string.Empty, 
                                     // However, on this line each `item` is of the type 
                                     // KeyValuePair and the `.Key` refers to the original's 
                                     // dictionary's key
                                     g => g.Select(item => item.Key).ToList())
                                     //Or: string.Join(", ", g.Select(item => item.Key))
                       .ToList();
    foreach (var pair in result)
    {
        Console.WriteLine("{0}: {1}", string.Join(", ", pair.Value), pair.Key);
    }
