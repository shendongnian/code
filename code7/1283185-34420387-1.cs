    var resultTask = Task.Factory.StartNew(new Action<object>(
      (x) => GetFor(x)), rawData);
    public string GetFor(string jedi)
    {
        Console.WriteLine("LightsaberProvider.GetFor jedi: {0}", jedi);
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (jedi == "2" && 1 == Interlocked.Exchange(ref _firstTime, 0))
        {
            throw new Exception("Dark side happened...");
        }
        Thread.Sleep(TimeSpan.FromSeconds(1));
        return string.Format("Lightsaver for: {0}", jedi);
    }
