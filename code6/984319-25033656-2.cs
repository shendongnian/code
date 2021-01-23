    public Action CallDoSomeMagic(string foo, SomeType obj)
    {
        return new Action(() => DoSomeMagic(foo, obj));
    }
    public void DoSomeMagic(string foo, SomeType obj)
    {
        // read and write obj.Bar here
    }
