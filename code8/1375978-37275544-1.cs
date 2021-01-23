    public Task InitializeAsync(...)
    {
        var task1stMessage = Send1stMessageAsync();
        // this thread will do everything inside Send1stMessageAsync until it sees an await.
        // it then returns control to this function until there is an await here:
        DoSomeThingElse();
        // after a while you don't have anything else to do, 
        // so you wait until your first messages has been sent
        // and the reply received:
        await task1stMessage;
        // control is given back to your caller who might have something
        // useful to do  until he awaits and control is given to his caller etc.
        // when the await inside Send1stMessageAync is completed, the next statements inside
        // Send1stMessageAsync are executed until the next await, or until the function completes.
        
        var task2ndMessage = Send2ndMessageAsync();
        DoSomethingUseful();
        await task2ndMessage;
    }
