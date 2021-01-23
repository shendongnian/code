    var data = File 
       .ReadAllLines(textfiletest)
       .Select(x => x.Split(':'))
       .Where(x => x.Length > 1);
    var dict = new Dictionary<string, string>();
    foreach (string[] parts in data)
    {
        string key = parts[0].Trim();
        if (!dict.ContainsKey(key))
        {
            dict.Add(key, parts[1]);
        }
    }
