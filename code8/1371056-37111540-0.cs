    List<double> tenorList = PMEC.InterestRateSet
        .Select(irs => irs.Tenor) 
        .ToList();
    List<double> rateList = PMEC.InterestRateSet
        .Select(irs => irs.Rate) 
        .ToList();
    List<double> tenorRateList = tenorList.Concat(rateList).ToList();
    // or...
    tenorList.AddRange(rateList); // modifies first list
