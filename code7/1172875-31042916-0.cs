    private async void ExecuteSafely(string message, Action intial, Action successAction)
    {
        try
        {
            await Task.Factory.StartNew(intial);
            successAction.Invoke();
        }
        catch (Exception e)
        {
            HandleException(e);
        }
    }
