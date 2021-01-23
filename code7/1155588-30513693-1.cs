    public async Task DoSomethingAndWaitAsync()
    {
        int i = 0
        while (i < 26)
        {
            Task.Run(() => DoSomething(i));
            await Task.Delay(TimeSpan.FromMinutes(1));
            i++;
        }
    }
