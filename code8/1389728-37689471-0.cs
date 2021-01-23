    IEnumerable<RenewalModel> result = 
        from r in renewalLists
        group r by r.CityID into grpCity
        let potentialRenewalCount = (from g in grpCity where g.CityID == grpCity.Key select g.PotentialRenewalCount).Sum()
	    let desiredCalculation = (PotentialRenewalCount/PotentialRenewalCount)*100
        select new RenewalModel
        {
        CityID = grpCity.Key,
        City = (from g in grpCity where g.CityID == grpCity.Key select g.City).First().Trim(),
        PotentialRenewalCount = potentialRenewalCount,
        PotentialRenewalSQRT = (from g in grpCity where g.CityID == grpCity.Key select g.PotentialRenewalSQRT).Sum(),
        DesiredCalucation =   desiredCalculation,
        RENEWALCOUNT = (from g in grpCity where g.CityID == grpCity.Key select g.RENEWALCOUNT).Sum(),
        RENEWALSQRT = (from g in grpCity where g.CityID == grpCity.Key select g.RENEWALSQRT).Sum()
    };
