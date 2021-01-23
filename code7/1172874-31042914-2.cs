    private async Task ExecuteSafelyAsync(string message, 
                                          Action initial, 
                                          Action successAction)
    {
        try
        {
            var task = await Task.Run(initial);
            successAction();
        }
        catch (Exception e)
        {
            // You get here if either Task.Run or successAction throws
        }
    }
