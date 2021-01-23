    public ActionResult Create()
        {
            return View();
        }
        // POST: ArtistGig/Create
        [HttpPost]
     public ActionResult Create(ArtistGig artistGig)
        {
            
            var userid = User.Identity.GetUserId();
            ///
            var artist = db.ArtistHubs.SingleOrDefault(a => a.ApplicationUserId == userid).Id;
                   artistGig.ArtistHubId = artist;
                    db.ArtistGigs.Add(artistGig);
                    db.SaveChanges();
                    return RedirectToAction("Index");
       
            }
 
    
