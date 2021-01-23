    Dictionary<string, int> dict1 = new Dictionary<string, int>();
    dict1.Add("first", 1);
    Dictionary<string, int> dict2 = new Dictionary<string, int>();
    dict2.Add("second", 2);
    dict2 = dict2.Concat(dict1).ToDictionary(k => k.Key, v => v.Value);
