    public async Task Process(CancellationTokenSource token)
    {
      await SpinUpServiceAsync();
      foreach (var item in LongList())
      {
        if (token.IsCancellationRequested) break;
        await LongTask1(item);
        if (token.IsCancellationRequested) break;
        await LongTask2(item);
        if (token.IsCancellationRequested) break;
        await LongTask3(item);
        if (token.IsCancellationRequested) break;
        await LongTask4(item);
        if (token.IsCancellationRequested) break;
        await LongTask5(item);
      }
      if (token.IsCancellationRequested)
      {
         Log($"Cancelled during {item}");
         await SpinDownServiceAsync();
         return;
      }
    }
