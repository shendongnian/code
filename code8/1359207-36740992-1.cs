    var queryresult = db.MFData.GroupBy(x => new 
        { 
            Scheme_Name = x.Scheme_Name, 
            Scheme_Code = x.Scheme_Code, 
            FundFamily = x.FundFamily 
        }).Select(group => new
        {
            Scheme_name = group.Key.Scheme_Name,
            Scheme_Code = group.Key.Scheme_Code,
            FundFamily = group.Key.FundFamily,
            Date = group.Max(x => x.Date),
            count = group.Select(x => x.Scheme_Code).Distinct().Count()
        }).OrderBy(x => x.Scheme_Code);
