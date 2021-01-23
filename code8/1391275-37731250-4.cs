    Task Action1()
    {
        // do stuff
        return Task.FromResult(true)
    }
    Task Action2()
    {
        // do more stuff
        return Task.FromResult(true)
    }
    
    async void DoInOrder()
    {
        await Action1(); // waits for Action1 to finish
        await Action2(); // waits for Action2 to finish
    }
