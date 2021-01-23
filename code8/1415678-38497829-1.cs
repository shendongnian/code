    try
    {
        SomeLegacyComOperation();
    }
    catch (COMException e)
    {
        if (e.ErrorCode = 0x1234)
        {
            // Handle error
        }
        else
        {
            throw;
        }
    }
