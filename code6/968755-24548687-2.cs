    [Test]
    public async Task LoopTest()
    {
        ...
        await eventManager.RaiseAsync<EventArgs>("A", null, null);
    }
