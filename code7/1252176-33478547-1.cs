    public ActionResult Index()
    {
        DateTimeOffset currentDate = DateTimeOffset.Now.AddDays(-1);
        IQueryable<Event> events = db.Events.Where(x => currentDate > x.EventTime);
        foreach(var e in events){ 
        {
            db.Events.Remove(e);
        }
        db.SaveChanges()
        return View(db.Events.ToList());
    }
