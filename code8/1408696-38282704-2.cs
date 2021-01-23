    string identifier = "title =";
    string data = File.ReadAllText("data.txt");
    
    List<String> results = new List<string>();
    
    foreach(string line in File.ReadAllLines("data.txt"))
    {
        if(line.Contains(identifier))
        {
            results.Add(line.Replace(identifier, string.Empty).Trim());
        }
    }
