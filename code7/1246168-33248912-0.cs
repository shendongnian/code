    public async Task<bool> GreetAsync(string name)
    {
      if (name == null)
        return false;
      await InternalGreeter.GreetAsync(name);
      return true;
    }
    private async Task<bool> GreetAndReportGreetedAsync(string name)
    {
      var result = await GreetAsync(name);
      WriteLine($"User {name} has been greeted.");
      return result;
    }
    public async Task GreetAllAsync()
    {
      await Task.WhenAll(UserNames.Select(un => GreetAsync(un));
    }
