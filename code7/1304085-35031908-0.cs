    public T Copy<T>()
        where T : BaseClass, new()
    {
        var copy = new T();
        // set all properties
        return T;
    }
