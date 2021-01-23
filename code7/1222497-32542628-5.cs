    private static void FillCountryLists(GuestInformationPresenter model)
    {
        var excludeKeys = new string[] { "GU", "XYZ" }; 
        model.FillCountryLists(ReservationService.RetrieveCountries(excludeKeys));
    }
