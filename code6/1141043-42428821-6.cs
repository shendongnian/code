    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateInput(false)]
    public ActionResult Edit([Bind(Include = "Id,Title,IntroText,Body,Modified,Author")] Post post)
    {
        using (UnitOfWork uwork = new UnitOfWork())
        {
            post.Modified = DateTime.Now;
            uwork.PostRepository.Update(post);
    
            uwork.Commit();
            return RedirectToAction("Index");
        }
    }
