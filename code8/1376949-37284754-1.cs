    try
    { 
        return Dns.GetHostAddresses(Website).First();
    }
    catch(InvalidOperationException iox)
    {
        throw new Exception("IP list was empty", iox);
    }
    catch(Exception x)
    {
        throw new Exception("Invalid website", x);
    }
