    public async Task DoSomething()
    {
        try
        {
            DoSyncWork();
            await Task.Run(() => AsyncStuff());
        }
        catch (Exception ex)
        {  
            // handle.
        }
    }
