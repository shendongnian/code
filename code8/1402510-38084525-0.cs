    [TestMethod]
    public async Task TimerTest()
    {
      await WpfContext.Run(() =>
      {
        _value = 0;
        var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(10)};
        timer.Tick += IncrementValue;
        timer.Start();
        await Task.Delay(15);
        Assert.AreNotEqual(0, _value);
      });
    }
