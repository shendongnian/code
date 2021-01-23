    public Task Bar()                       //    public async Task Bar()
    {                                       //    {
        Baz();                              //        Baz();
        return Task.CompletedTask;          //
    }                                       //    }
