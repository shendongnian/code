    public T getObject<T>() where T : A
    {
       return (new T());
    }
    var myObject = getObject<A1>(); // works
    var myObject = getObject<A2>(); // also works
