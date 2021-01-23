    Dictionary<string, int> result = new Dictionary<string, int>();
    for(int i = 0; i < data.Count ; i++)
    {
        string line = data[i];
        string[] element  = line.Split(' '); //assuming your data is a string like in your example
        string key = element[0];
        int value = int.Parse(key[1]);
        result[key] += value;
    }
