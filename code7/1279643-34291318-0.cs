    Dictionary<string, List<string>> poi = new Dictionary<string, List<string>>();
    foreach (string line in File.ReadLines(@"D:\temp\poi.txt"))
    {
        string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        poi.Add(parts[0], new List<string>());
        poi[parts[0]] = new List<string>(parts.Skip(1));
    }
