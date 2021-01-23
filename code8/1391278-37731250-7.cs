    Task<int> GetMyInt()
    {
        int value = 3;
        return Task.FromResult(value);
    }
    async void DoWithMyInt()
    {
        int SomeInt = await GetMyInt(); // will wait for GetMyInt()
                                        // to return then assign value
                                        // to SomeInt and then continue
    }
