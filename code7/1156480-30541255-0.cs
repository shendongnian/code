    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "HomeId,Name")] Home home)
    {
        if (ModelState.IsValid)
         {
             db.Homes.Add(home);
             db.SaveChanges();
             RelUserHomes relUserHomes = new RelUserHomes();
    
             relUserHomes.HomeId = home.HomeId;
             db.RelUserHomes.Add(relUserHomes);
             db.SaveChanges();
    
        }
        return View(home);
    }
