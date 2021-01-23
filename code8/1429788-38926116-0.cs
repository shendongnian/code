    private void StartClock()
    {
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        timer.Tick += async (o, e) => await GetIP();
        timer.Start();
    }
    private async Task GetIP()
    {
        Debug.WriteLine("Checking ip");
        await Task.Run(() =>
        {
            // get your IP asynchronously here
        });
        Debug.WriteLine("Found ip");
    }
