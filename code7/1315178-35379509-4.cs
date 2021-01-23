    model = new MyViewModel();
    model.Countries = db.SetupCountry.ToList();
    model.AllRecords  = model.Countries.Count();
    model.IsActiveRecords = model.Countries.Count(c => c.IsActive);
    model.IsDeletedRecords = model.Countries.Count(c => c.IsDeleted);
