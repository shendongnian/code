    public string getX (string request, string x)
    {
        using (var soapClient = new ServiceReference1.CustomDataTimetableToolKitServicesSoapClient(EndpointConfiguratioName, Endpoint))
        {
            switch (x)
            {
                case "schedules":
                    return soapClient.GetSchedules(AuthenticationInfo, request);
                    break;
                case "countryList":
                    return soapClient.GetCountryList(AuthenticationInfo, request);
                    break;
                case "carriers":
                    return soapClient.GetCarriers(AuthenticationInfo, request);
                    break;
                }
            }
        }
    }
