    var dictionary = new HeterogeneousDictionary();
    var keyName = new HeterogeneousDictionaryKey<string>("keyName");
    var keyAge = new HeterogeneousDictionaryKey<int>("keyAge");
    dictionary.Set(keyName, "Orace");
    dictionary.Set(keyAge, 8);
    ...
    var name = dictionary.Get(keyName);
    var age = dictionary.Get(keyAge);
