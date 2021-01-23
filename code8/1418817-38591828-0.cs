    private async Task<int> SomeTaskAsync(int param, bool sync)
    {
      // Every `await` in your code needs to honor `sync`
      if (sync)
        return SomeOtherTask();
      else
        return await SomeOtherTaskAsync();
    }
    public int SomeTask(int param) 
    {
      return SomeTaskAsync(param, sync: true).GetAwaiter().GetResult();
    } 
    public Task<int> SomeTaskAsync(int param) 
    {
      return SomeTaskAsync(param, sync: false);
    } 
