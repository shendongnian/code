    async void Action1()
    {
        int ResultofAction2 = await Action2(); // Which will wait for Action2
                                               // to return the value that's
                                               // going to equal 2
    }
    async Task<int> Action2()
    {
        int value = 2;
        return value;
    }
