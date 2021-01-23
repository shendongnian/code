    protected void Expose(string name, Action method)
    {
        method(); // will invoke the method passed.
    }
    protected void Expose(string name, Func<SomeType> method)
    {
        var value = method(); // will invoke the method passed and assign return result to value.
    }
