    public async void Foo(int limit){
        await DoStuffForAWhile(limit);
        TheBoundProperty = "But this is!";
    }
    public async Task DoStuffForAWhile(int limit)
    {
      TheBoundProperty = "This is not shown.";
    
      DateTime start = DateTime.Now;
      TimeSpan elapsed;
      do
      {
        elapsed = new TimeSpan(DateTime.Now.Ticks - start.Ticks);
        TheBoundProperty = "Neither is this.";
        await Task.Delay(1000); //1 sec delay
      } while (elapsed.TotalSeconds < limit);
    }
