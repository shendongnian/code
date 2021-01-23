    async Task Action1()
    {
        //Stuff
    }
    async Task Action2()
    {
        //More Stuff
    }
    
    async void DoInOrder()
    {
        await Action1(); //Waits for Action1 to finish
        await Action2(); //Waits for Action2 to finish
    }
