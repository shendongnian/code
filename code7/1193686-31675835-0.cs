    public void Foo(int p1, MyClass fooObj)
    {
        . . .
    }
    
    public void Foo(int p1)
    {
        var fooObj = LoadFooObj(....);
        Foo(p1, fooObj);
    }
