    public async Task<string> AsyncString()
    {
        await Task.Delay(1000);
        return "TestAsync";
    }
    public void Test()
    {
        string string1 = "";
        string string2 = "";
        using (var A = AsyncHelper.Wait)
        {
            A.Run(AsyncString(), res => string1 = res);
            A.Run(AsyncString(), res => string2 = res);
        }
    }
