    public ServiceReference1.CustomDataTimetableToolKitServicesSoapClient NewClient()
    {
        return new ServiceReference1.CustomDataTimetableToolKitServicesSoapClient(EndpointConfiguratioName, Endpoint)
    }
    using (var client = NewClient()) {
        return soapClient.GetCountryList(AuthenticationInfo, request);
    }
