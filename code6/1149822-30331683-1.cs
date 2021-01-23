    public Foo Get(string id)
    {
        var foo = _service.Get<Foo>(username);
        return foo;
    }
