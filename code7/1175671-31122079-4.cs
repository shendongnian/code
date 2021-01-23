    var result = MessageBoxHelper.MsgBox
        .ShowAsync("Press Yes to proceed", MessageBoxButton.YesNo)
        .ContinueWith(async (answer) =>
        {
            if (answer.Result == MessageBoxResult.Yes)
            {
                await ExecuteAsyncFunc();
            }
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
    public async Task<bool> ExecuteAsyncFunc()
    {
        await CallAnotherAsyncFunction();
    }
