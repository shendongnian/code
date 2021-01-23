    Dictionary<string, string> mappings = new Dictionary<string, string>();
    // gets an array lines in the file
    var lines = System.IO.File.ReadAllLines("TextFile1.txt");
    foreach(var line in lines)
    {
        //this gets an array of substrings, seperated by the specified character
        var vals = line.Split('=');
        //adds a value to your dictionary
        mappings.Add(vals[0], vals[1]);
    }
