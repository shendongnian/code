    var splitted = new List<string>();
    for(int i = 0; i < a.Length; i += 4)
    {
        var s = new string(a.Skip(i).Take(4).ToArray());
        splitted.Add(s);
    }
