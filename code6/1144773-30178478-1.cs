    public string GetSchedules(string request)
    {
        return Worker((c) => c.GetSchedules(AuthenticationInfo, request));
    }
    public string GetCountryList(string request)
    {
        return Worker((c) => c.GetCountryList(AuthenticationInfo, request));
    }
    public string GetCarriers(string request)
    {
        return Worker((c) => c.GetCarriers(AuthenticationInfo, request));
    }
    private string Worker(Func<SoapClientClassGoesHere, string> f)
    {
        using (var soapClient = new ServiceReference1.CustomDataTimetableToolKitServicesSoapClient(EndpointConfiguratioName, Endpoint))
        {
            return f(soapClient);
        }
    }
