    [HttpPost]
    public ActionResult Edit(Post post)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Post oldPost = db.Posts.Find(post.id);
                oldPost.Published=post.Published;
                // repeat for others. 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
           //
        }
    }
