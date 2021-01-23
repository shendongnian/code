    try     // <--- This ...
    {
        try
        {
            // Code to invoke SetMethod.
        }
        catch(Exception)
        {
            // Code to rewind.
            // Code to throw inner or rethrow.
        }
    }
    finally // <--- ... and this consume the exception before you can handle it.
    {
        // Code to raise change notification.
    }
