    List<string[]> original = new List<string[]>
    {
        new string[3] { "a", "2", "3" },
        new string[3] { "x", "2", "3" },
        new string[3] { "c", "2", "3" }
    };
    List<string[]> web = new List<string[]>
    {
        new string[3] { "a", "2", "3" },
        new string[3] { "b", "2", "3" },
        new string[3] { "c", "2", "3" }
    };
    
    var originalPrimaryKeys = original.Select(o => o[0]);
    var webPrimaryKeys = web.Select(o => o[0]);
    
    List<string> differences = originalPrimaryKeys.Except(webPrimaryKeys).ToList();
    
    Console.WriteLine("The number of differences is {0}", differences.Count);
    foreach (string diff in differences)
    {
        Console.WriteLine(diff);
    }
