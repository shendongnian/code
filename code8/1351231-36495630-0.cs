    var dupChecker = new HashSet<string>();
    var duplicates = new List<string>();
    foreach(string res in arr)
    {
        if (!dupChecker.Add(res))
        {
            duplicates.Add(res);
        }
    }
    
    string[] result = duplicates.ToArray();
