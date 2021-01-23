    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,DisplayName,Date,Amount,Comment")] Charity charity)
    {
        if (ModelState.IsValid)
        {
            if(!string.IsNullOrEmpty(charity.Comment)
            {
               var comment = charity.Comment.ToLower().Replace("hot","###").Replace("cold","###");
               charity.Comment = comment;
            }
            db.Donations.Add(charity);
            db.SaveChanges();
            return RedirectToAction("Additionalinfo", "Charities");
        }
        return View(charity);
    }
