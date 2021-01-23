    private void ExecuteSafely(string message, Action initial, Action successAction)
    {
        var task = Task.Factory.StartNew(initial).ContinueWith(t =>
        {
            if (t.Exception != null)
            {
                HandleException(t.Exception);
            }
            else
            {
                try
                {
                   successAction();
                }
                catch (Exception e)
                { 
                    // Handle your exception.
                }
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
