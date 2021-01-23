    void Add(MyClass item)
    {
        if (!_index.ContainsKey[item.Key])
        {
            _collection.Add(item);
            _index.Add(item.Key, item);
        }
    }
