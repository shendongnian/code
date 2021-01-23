    // GET: Ratings/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Ratings ratings = db.Ratings.Find(id).Include("MP");
        if (ratings == null)
        {
            return HttpNotFound();
        }       
        return View(ratings);
    }
