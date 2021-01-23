    string myString = "Hello world, '4567' is my number 679.";
    var matches = Regex.Matches(myString, "\\d");
    for (int i = 0; i < matches.Count; i++)
    {
        Console.WriteLine(string.Format("Match {0}: {1}", i + 1, matches[i].ToString()));
    }
