    // Catch the exception
    catch(exception e)
    {
        // Check if the type of the exception is an RFC exception.
        if(e is SAP.Middleware.Connector.RfcCommunicationException)
        {
        }
        else // It is not an RFC exception.
        {
        }
    }
