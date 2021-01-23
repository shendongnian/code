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
                       .ToDictionary(g => g.Key, 
                                     g => g.Select(item => item.Key).ToList()).ToList();
    foreach (var pair in result)
    {
        Console.WriteLine("{0}: {1}", string.Join(", ", pair.Value), pair.Key);
    }
