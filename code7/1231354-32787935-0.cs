    private string GetJobs(Gateway gateway)
    {
        ConfigLogger.Instance.LogInfo("info", "Calling Gateway Start: " + DateTime.Now.ToString("HH:mm:ss.ffff") + " for engineer: " + gateway.Engineer);
        string gatewayResult = CallGateway(gateway);
        ConfigLogger.Instance.LogInfo("info", "Calling Gateway End: " + DateTime.Now.ToString("HH:mm:ss.ffff") + " for engineer: " + gateway.Engineer);
        if (gatewayResult != null)
        {
            ConfigLogger.Instance.LogInfo("info", "Processing Request Message: " + DateTime.Now.ToString("HH:mm:ss.ffff") + " for engineer: " + gateway.Engineer);
            ProcessMessageNew(gatewayResult, gateway);
        }
        return gatewayResult;
    }
