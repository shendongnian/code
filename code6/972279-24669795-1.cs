    public IDictionary<T, Animal> GetDictionary()
    {
        _dictionary = new Dictionary<T, Llama>();
        return _dictionary; // Imagine you can do this
    }
    IDictionary<T, Animal> dict = GetDictionary();
    dict.Add(MakeT(), new Horse()); // Ouch.
