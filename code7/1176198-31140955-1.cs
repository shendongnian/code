    // presize, because we know that there are
    // at least data.Length elements!
    var list = new List<string>(data.Length);
    for (var i = 0; i < data.Length; i++)
    {
        if (data[i] == "5")
        {
            list.Add("");
        }
        list.Add(data[i]);
    }
    data = list.ToArray();
