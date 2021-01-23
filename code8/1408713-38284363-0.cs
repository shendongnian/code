    var dictionary = new Dictionary<string, string>();
    dictionary.Add("a.exe", "aGroup");
    dictionary.Add("b.exe", "bGroup");
    
    string val;
    if (dictionary.TryGetValue(processName, out val))
        processInfo.Group = val;
    else
        processInfo.Group = ”Undefined Group”;
