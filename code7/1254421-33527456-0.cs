    public IEnumerable<Event> GetUser(string userId)
    {
       var users = db.Events.Where(x => x.EventCreator == userId);
       foreach (var user in users)
       {
          yield return user;
       }
    }
    
    public ActionResult YourEvents()
    {
       var userId = User.Identity.Name;
       var users = new List<Event>(GetUser(userId));
       return View(users);
    }
