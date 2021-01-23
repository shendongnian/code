    public T Initial<T,S>() where T : new() where S : SomeType, new()
    {
        T t = new T();
        if (t is IHasSome)
        {
            ((IHasSome)t).BArray = new S();
        }
        return t;
    }
