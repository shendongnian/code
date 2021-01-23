    List<string> names = new List<string>();
    names.AddRange(names1);
    names.AddRange(names2);
    names.Sort();
    string[] names3 = names.Distinct().ToArray();
