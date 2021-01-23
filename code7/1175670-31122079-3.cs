    public Task<bool> Foo()
    {
        var result = await MessageBoxHelper.MsgBox
            .ShowAsync("Press Yes to proceed", MessageBoxButton.YesNo);
  
        if (result == MessageBoxResult.Yes)
        {
            await ExecuteAsyncFunc();
            return true;
        }
        return false;
    }
    public async Task<bool> ExecuteAsyncFunc()
    {
        await CallAnotherAsyncFunction();
    }
