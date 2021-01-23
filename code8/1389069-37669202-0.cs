    // client code
    public async void TopLevelMethod()
    {
      await MyMethodAsync();
    }
    // library code -- his implementation
    public async Task MyMethodAsync()
    {
        await AnotherOperationAsync();
    }
