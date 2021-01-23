    [HttpPost]
    public ActionResult Meeting(ViewModel ViewModel)
    {
    //The Error appears if the following part isnt commented out -->
    //var ALL = db.Sites.Where(p => p.Content.Any(a => a.Date.CompareTo(DateTime.Now) <= 0)).OrderBy(l => l.Customer.Service).ToList();
    //Adding informations that arnt added by user
    ViewModel.Changing.LastUpdate = DateTime.Now;
    ViewModel.Changing.LastUpdaterId = UpdaterID;
    Site current = ViewModel.Changing;
    if (ModelState.IsValid)
    {
        db.Entry(current).State = EntityState.Modified; //Here is the error
        db.SaveChanges();
    }
    //... 
    }
