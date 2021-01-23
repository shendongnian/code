    var client = new ImapClient(hostname, true)
    try
    {
        ...
    }
    finally
    {
        if (client != null)
        {
            ((IDisposable)client).Dispose();
        }
    }
