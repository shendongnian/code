    public void AddDelegate<T>(Action<T> del) where T : ISomeInterface
    {
        var list = default(List<Action<ISomeInterface>>);
        if (!_delegates.TryGetValue(typeof(T), out list))
            _delegates[typeof(T)] = list = new List<Action<ISomeInterface>>();
         list.Add(si => del((T)si));   
    }
