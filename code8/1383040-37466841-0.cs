    [WebMethod]
    public static void MethodSearch()
    {
        //Search
        string _sEnrollmentEsiid;
        string _sEnrollmentAddress;
        string _sEnrollmentCity;
        string _sEnrollmentZipCode;
        //string _sAMS;
        //_sEsiidText
        GetDistributionPointsRequest disRequest = new GetDistributionPointsRequest();
        _sEnrollmentEsiid = disRequest.EsiID;
        _sEnrollmentAddress = disRequest.Address;
        _sEnrollmentCity = disRequest.City;
        _sEnrollmentZipCode = disRequest.Zip;
    }
