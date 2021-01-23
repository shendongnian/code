    public string GetCarriers(string request)
    {
        return Get((client, authInfo, request) => client.GetCarriers(authInfo, request));
    }
    ...
    
    public string Get(Func<ISoapClient, AuthenticationInfo, string, string> action, string request) {
        using (var soapClient = new ServiceReference1.CustomDataTimetableToolKitServicesSoapClient(EndpointConfiguratioName, Endpoint))
        {
            return action(soapClient, AuthenticationInfo, request)
        }
    }
