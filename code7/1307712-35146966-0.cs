    public ActionResult AnnounceRead()
     {
        using (var db = new HarmonyMainServerDbContext())
    {
        var announceList = db.Announcer.Select(x=> new ANNOUNCEMENT{
                           AnnounceTitle = x.AnnounceTitle,
                           AnnounceLink = x.AnnounceLink
     }).ToList();
                         
        return View("Index", announceList);
    }
   }
