    var list = new List<string>();
    for (var i = 0; i < data.Length; i++)
    {
        if (data[i] == "5")
        {
            list.Add("");
        }
        list.Add(data[i]);
    }
    data = list.ToArray();
