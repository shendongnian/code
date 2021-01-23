    private static void UnhandledError(object sender, UnhandledErrorDetectedEventArgs eventArgs)
    {
        try
        {
            // A breakpoint here is generally uninformative
            eventArgs.UnhandledError.Propagate();
        }
        catch (Exception e)
        {
            // Set a breakpoint here:
            Debug.WriteLine("Error: {0}", e);
            throw;
        }
    }
