    Dictionary<string, car> dictionary = new Dictionary<string,car>();
    if(!dictionary.ContainsKey(name))
    {
         dictionary.Add(name, new car());
    }
