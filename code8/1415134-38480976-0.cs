    public async Task<int> DoSomethingAsync()
    {
        DoSomethingElse()
        var result = await GetValueAsync();
        var intValue = DoAnotherThing(result);
        return intValue;
    }
