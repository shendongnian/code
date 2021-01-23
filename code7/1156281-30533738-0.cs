    public ActionResult Index()
    {
    
        var model = db.Tickets
                      .Include(t=>t.TicketNotes)
                      .Where(t.OpenUserId == new Guid("00000000-0000-0000-0000-000000000000"))
                      .OrderBy(t=>t.OpenDate);
    
        return View(model);
    }
