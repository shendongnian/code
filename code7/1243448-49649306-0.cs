    public ActionResult Index(string searchid)
    { 
    var personTables = db.PersonTables.Where(o => o.Name.StartsWith(searchid) )||  o.CombanyTable.ComName.StartsWith(searchid) ).Include(k => k.CombanyTable);
    return View(personTables.ToList());
    }
