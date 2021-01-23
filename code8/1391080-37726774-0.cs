    int targetTicks = Environment.TickCount + (10 * 1000);
    
    async Task WaitUntilTargetReachedAsync() {
     while (true) {
      var currentTicks = Environment.TickCount;
      if (currentTicks >= targetTicks) break; //Target reached.
      await Task.Delay(TimeSpan.FromMilliseconds(targetTicks - Environment.TickCount));
     }
    }
