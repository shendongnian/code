    public async Task DoSomething1(int aqq)
    {
        await DoAnotherThingAsync(aqq); //blocks here and wait DoAnotherThingAsync to respond
        SomethingElse();
    }
    public Task DoSomething2(int aqq)
    {
        var task = DoAnotherThingAsync(aqq); //keep going here, not waiting for anything
        SomethingElse();
        return task;
    }
    public async Task DoAnotherThingAsync(int aqq)
    {
        await Task.Delay(100);
    }
    public void SomethingElse()
    {
        //do something
    }
