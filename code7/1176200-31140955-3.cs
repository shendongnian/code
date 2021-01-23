    // presize, because we know that there are
    // at least data.Length elements!
    // technically the final array will have a size
    // data.Length <= finalSize <= data.Length * 2
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
