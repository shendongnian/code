    private List<cDTOCountry> GetCountries()
    {
        inputCollection = new cDTOCollection<cDTOBase>();
        outputCollection = new cDTOCollection<cDTOBase>();
        return UpdateProfileBizobj.ProcessRequest(ActionConstants.ActionGetCountriesList, null);
    }
    
