    var dictionary = new Dictionary<string, SomeType>();
    foreach(var item in model)
    {
        dictionary.Add(item.Key, SomeType.FromDynamic(item.Value));
    }
