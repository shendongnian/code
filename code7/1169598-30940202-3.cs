    [HttpGet]
    public ActionResult EditUserTicket(EditTicketViewModel model)
    {
       var model = db.Tickets
                  .Include(t => t.TicketNotes)
                  .Where(t => t.TicketId == model.TicketId).First();
       return View(model);
    }
