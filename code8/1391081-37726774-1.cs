    volatile int targetTicks = Environment.TickCount + (10 * 1000);
    
    async Task WaitUntilTargetReachedAsync() {
     while (true) {
      var currentTicks = Environment.TickCount; //stabilize value
      var targetTicksLocal = targetTicks; //volatile read, stabilize value
      if (currentTicks >= targetTicksLocal) break; //Target reached.
      await Task.Delay(TimeSpan.FromMilliseconds(targetTicksLocal - currentTicks));
     }
    }
