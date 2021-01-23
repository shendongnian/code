    try
    {
        await app.AcquireTokenSilentAsync(...).ContinueWith(
                    t =>
                    {
                        if (t.Exception != null)
                        {
                            t.Exception.Handle(
                                ex =>
                                {
                                    if (ex is TaskCanceledException)
                                    {
                                        Console.WriteLine("Task cancelled {0}", ex);
                                    }
                                    else
                                    {
                                        Console.WriteLine(ex);
                                    }
                                    return false;
                                });
                        }
                    },
                    TaskContinuationOptions.OnlyOnFaulted);;
    }
    catch(Exception e)
    {
        /Console.WriteLine(ex);
    } 
