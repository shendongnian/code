    try
    {
        SomeLegacyComOperation();
    }
    catch (COMException e) when (e.ErrorCode == 0x1234)
    {
        ...
    }
    catch (COMException e) when (e.ErrorCode == 0x5678)
    {
        ...
    }
