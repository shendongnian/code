    public void SortOutOnlyActiveOrPaidCats()
    {
        var validStatuses = new [] { "Active", "Paid" };
        var validCodes = new [] { "1", "2", "3", "4" };
    
        AllCats = AllCats.Where(x => 
            validStatuses.Contains(x.CatStatus) &&
            validCodes.Contains(x.CatCode) &&
            x.CatEnrollmentCode != "G" &&
            (x.CatType != "TacoCat" || x.Age >= 65)
        );
    }
