    public string GetCarriers(string request)
    {
        return Get((AuthenticationInfo, request) => soapClient.GetCarriers(AuthenticationInfo, request), request);
    }
    ...
    
    public string Get(Func<AuthenticationInfo, string, string> action, string request) {
        using (var soapClient = new ServiceReference1.CustomDataTimetableToolKitServicesSoapClient(EndpointConfiguratioName, Endpoint))
        {
            return action(AuthenticationInfo, request)
        }
    }
