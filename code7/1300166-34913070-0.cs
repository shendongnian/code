    Country county = db.Countie.FirstOrDefault(c => c.NameId == model.County);
    if(county == null)
    {
	     ModelState.AddModelError("", "Invalid County");
    }
    else
    {
	    user.Address.City.County = county;
    }
