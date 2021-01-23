    private async Task<bool> CancelAt(TypeOfItem item)
    {
      Log($"Cancelled during {item}");
      await SpinDownServiceAsync();
      return false; // cancel
    }
    public async Task<bool> Process(CancellationTokenSource token)
    {
      await SpinUpServiceAsync();
      foreach (var item in LongList())
      {
        if (token.IsCancellationRequested) return await CancelAt(item);
        await LongTask1(item);
        if (token.IsCancellationRequested) return await CancelAt(item);
        await LongTask2(item);
        if (token.IsCancellationRequested) return await CancelAt(item);
        await LongTask3(item);
        if (token.IsCancellationRequested) return await CancelAt(item);
        await LongTask4(item);
        if (token.IsCancellationRequested) return await CancelAt(item);
        await LongTask5(item);
      }
      return true; // all done
    }
