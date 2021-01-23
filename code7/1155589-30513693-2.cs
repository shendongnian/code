    public async Task DoSomethingAndWaitAsync()
    {
        for (int i = 0; i < 26; i++)
        {
            Task.Run(() => DoSomething(i));
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
