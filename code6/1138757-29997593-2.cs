    public void Register<T>(Func<T, T> unaryFunc)
    {
        _unaryFuncs[typeof(T)] = unaryFunc;
    }
    public void Register<T>(Func<T, T, T> binaryFunc)
    {
        _binaryFuncs[typeof(T)] = binaryFunc;
    }
