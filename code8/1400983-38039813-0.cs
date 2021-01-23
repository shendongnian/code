    [Obsolete("Call Foo2() instead of the deprecated Foo()", true)]
    public void Foo<T>(IQueryable<T> input)
    {
        Foo2(input);
    }
    public void Foo2(IQueryable input)
    {
    ...
    }
