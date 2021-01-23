    _checkedMetainfoValues = new MyStrangeDictionary();
    _checkedMetainfoValues.Add(new MetaInfoValueGroupTag { MetaInfo = "f"}, new List<object> { "first"});
    _checkedMetainfoValues.Add(new MetaInfoValueGroupTag { MetaInfo = "s"}, new List<object> { "second", "2"});
    var test = _checkedMetainfoValues["f"];
    foreach (var t in test)
    {
        Console.WriteLine(t);
    }
    List<object> test1;
    _checkedMetainfoValues.TryGetValue("s", out test1);
    foreach (var t in test1)
    {
        Console.WriteLine(t);
    }
