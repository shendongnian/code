    Ping ping = new Ping();
    PingReply pr = null;
    bool pingError = false;
    try
    {
        pr = ping.Send("http://myservername.fake", 5000);
    }
    catch
    {
        pingError = true;
    }
    finally
    {
        /* Short-curcuit here, because pr.Status might still be 
         null if no network connectivity at all. */
        if (pingError || pr.Status != IPStatus.Success)
        {
            // Here we know we are offline
        }
        else
        {
            // Here we know we are online
        }
    }
