    Dictionary<string, string> dictionary;
    foreach(string line in file)
    {
        if(string.IsNullOrWhiteSpace(line)) continue;
    
        // Remove extra spaces
        line = line.Trim();
        if(line[0] == '#') continue;
        
        string[] kvp = line.Split('=');
        dictionary[kvp[0].Trim()] = kvp[1].Trim(); // kvp[0] = key, kvp[1] = value
    }
