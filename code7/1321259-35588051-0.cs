    bool success = true;
    while(success)
    {
        try
        {
            LoadRequests();
            Thread.Sleep(500);
        }
        catch (exception ex)
        {
            //Log Error ex.Message;
            success = false;
        }
    }
