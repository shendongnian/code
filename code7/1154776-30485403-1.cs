    var list = new List<List<string>>();
    list.Add(new List<string>());
    list[0].Add("january");
    list[0].Add("2");
    list[0].Add("3");
    ...
    Service.sendList(list.ToArray());
