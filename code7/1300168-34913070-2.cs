    ApplicationDbContext db = new ApplicationDbContext();
    Country county = db.Countie.FirstOrDefault(c => c.NameId == model.CountyId);
    if(county == null)
    {
	     ModelState.AddModelError("", "Invalid County");
    }
    else
    {
	    user.Address.City.County = county;
    }
