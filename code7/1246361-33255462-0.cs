    public void SomeMethod<T> ()
        where T : IClientHandler, new()
    {
        IClientHandler handler = new T();
        // do stuff
    }
