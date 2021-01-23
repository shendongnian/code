    public Task<string> Foo()               //    public async Task<string> Foo()
    {                                       //    {
        Baz();                              //        Baz();
        return Task.FromResult("Hello");    //        return "Hello";
    }                                       //    }
