    public SomeResult FooBarBaz()
    {
        var myModel = new SomeComplexObject();
        myModel.Foo = "foo";
        myModel.Bar = "bar";
        myModel.Baz = 123;
        var result = repository.GetTheResult(myModel);
        return result;
    }
