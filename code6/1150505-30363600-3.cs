    public ActionResult Details (int id, string slug)
    {
        if (string.IsNullOrEmpty(slug))
        {
            // Look up the slug in the database based on the id, but for testing
            slug = "this-is-a-slug";
            return RedirectToAction("Details", new { id = id, slug = slug });
        }
        var model = db.Questions.Find(id);
        return View(model);
    }
