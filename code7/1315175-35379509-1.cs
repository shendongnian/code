    model = new MyViewModel{
        Countries = db.SetupCountry.ToList(),
        AllRecords = db.SetupCountry.Count(),
        IsActiveRecords = db.SetupCountry.Count(c => c.IsActive),
        IsDeletedRecords = db.SetupCountry.Count(c => c.IsDeleted),
    }
