    private async Task<bool> CanUseTrial()
    {
        var clientCode = GenerateClientCode(); // However you're going to do this
    #if OEM        
        WebServiceXyz.RegisterOemClient(clientCode);
        return true;
    #else
        try
        {
            return await WebServiceXyz.IsRegisteredOemClient(clientCode);
        }
        catch
        {
            return false;
        }
    #endif
    }
