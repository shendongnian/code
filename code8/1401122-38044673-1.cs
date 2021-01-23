    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddComment(comment cmt)
    {
        if (ModelState.IsValid)
        {
            db.comments.Add(cmt);
            db.SaveChanges();
            return RedirectToAction("Index", "Comment");
        }
        return View(cmt);
    }
