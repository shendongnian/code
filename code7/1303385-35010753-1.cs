    try
    {
        try
        {
            // do stuff
            return response.Result;
        }
        catch (Exception ex)
        {
            // Something has gone badly wrong so we'll need to throw
            // Log the info
            throw;
        }
    }
    finally
    {
        if (client != null)
            client.Dispose();
    }
    
