    string[] data = {"1","2","3","5","6","7","4"};
    var list = new List<string>(data);
    for (var i = 0; i < list.Count; i++)
    {
        if (list[i] == "5")
        {
            list.Insert(i, "");
            i++;
        }
    }
    data = list.ToArray();
