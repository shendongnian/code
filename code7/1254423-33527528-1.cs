    public ActionResult YourEvents()
    {
       var userId = User.Identity.Name;
       IEnumerable<Event> userListing = db.Events.Where(x => x.EventCreator == userId);
       return View("EventErrorCreateMessage", "Event", userListing );
    }
