    var strings = new List<string>
    {
        "Case 1: Bug A is resolved (XID: X015)",
        "Case 2: Bug B is resolved (ZID: X016)",
        "Case 3: Bug C is resolved (Data issue) (SID: X017)"
    };
    foreach (var s in strings)
    {
        var result = s.Substring(s.LastIndexOf('('));
        System.Console.WriteLine(result);
    }
