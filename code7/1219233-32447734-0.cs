    BL.Case mCase = null;
    var temp = db.Cases.Select(
                    xx => new
                    {
                        CaseID = xx.CaseID,
                        FirstName = xx.FirstName,
                        LastName = xx.LastName
                    }).FirstOrDefault(u => u.CaseID == CaseID);
    if (temp != null)
    {
        mCase = Mapper.DynamicMap<BL.Case>(temp);
    }
