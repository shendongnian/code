    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateInput(false)]
    public ActionResult Edit([Bind(Include = "Id,Title,IntroText,Body,Modified,Author")] Post post)
    {
        using (UnitOfWork uwork = new UnitOfWork())
        {
            Post edit = uwork.PostRepository.GetById(post.Id);
            edit.Title = post.Title;
            edit.IntroText = post.IntroText;
            edit.Body = post.Body;
            edit.Modified = DateTime.Now;
    
            uwork.Commit();
            return RedirectToAction("Index");
        }
    }
