    var dictionary = File.ReadLines(@"Test.csv").Select(line => line.Split(',')).ToDictionary(data => data[0], data => data.Skip(1).Take(data.Count - 3));
    if (dictionary.ContainsKey(variable.ToString()))
    {
        var tmp = dictionary[variable.ToString()]
        foreach(string str in tmp)
           Description.Add(str);
    }
