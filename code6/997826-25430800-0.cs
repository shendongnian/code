    var list = new List<string> {
        "1A", "3B", "5X", "7Q", "2W", "2G", "2J", "1B", "1C", "1D", "1E"
    };
    var groups = new List<List<string>>();
    char lastChar = (char)0; // We assume that NUL will never be used as first char.
    List<string> group = null;
    foreach (string s in list) {
        if (s[0] != lastChar) {
            group = new List<string>();
            groups.Add(group);
            lastChar = s[0];
        }
        group.Add(s);
    }
    // Join the first and the last group if their first char is equal
    int lastIndex = groups.Count - 1;
    if (groups.Count > 2 && groups[0][0][0] == groups[lastIndex][0][0]) {
        // Insert the elements of the last group to the first group
        groups[0].InsertRange(0, groups[lastIndex]);
        // and delete the last group
        groups.RemoveAt(lastIndex);
    }
    //TODO: Remove test
    foreach (List<string> g in groups) {
        Console.WriteLine(g[0][0]);
        foreach (string s in g) {
            Console.WriteLine("   " + s);
        }
    }
    // Now create a list with items of groups having more than 4 duplicates 
    var result = new List<string>();
    foreach (List<string> g in groups) {
        if (g.Count > 4) {
            result.AddRange(g);
        }
    }
    //TODO: Remove test
    Console.WriteLine("--------");
    foreach (string s in result) {
        Console.Write(s);
        Console.Write("  ");
    }
    Console.WriteLine();
    Console.ReadKey();
