    public ActionResult Clubs(int comp)
    {
    	var dbContext = new DataDBEntities();
    	var query = from clubs in dbContext.Clubs where clubs.League_Table == comp select clubs;
    	var data = query.ToList();
    
    	if (data.Count == 0) ViewData.Model = dbContext.Clubs.ToList();
    	else ViewData.Model = data;
    
    	return View();
    }
