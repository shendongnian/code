    private Dictionary<Object, Task> _Workers = new Dictionary<object, Task>();
    private void OnButton1Click(object sender, EventArgs e)
    {
        StartIfNotBusy(sender);
    }
    private void OnButton2Click(object sender, EventArgs e)
    {
        StartIfNotBusy(sender);
    }
    private void StartIfNotBusy(object sender)
    {
        Task worker;
        if (_Workers.TryGetValue(sender, out worker)
            && !worker.IsCompleted)
        {
            Console.WriteLine("Sorry, I'm currently busy.");
            return;
        }
        _Workers[sender] = DoSomething();
    }
    private Task DoSomething()
    {
        return Task.Delay(1000).ContinueWith(_ => Console.WriteLine("Hey, I finished working."));
    }
