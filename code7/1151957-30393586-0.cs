    try
    {
        ... code throwing ConnectionBrokenException
    }
    catch(ConnectionBrokenException ex)
    {
        _logger.LogError("Something bad has happened with connection", ex.Message);
    }
    catch(Exception)
    {
        // handles other types of exceptions
    }
