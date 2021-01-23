    [HttpPost]
    // POST: api/Forum
    [Route("post")]
    public void PostNewMessage(ForumPost p)
    {
        if (ModelState.IsValid)
        {
            db.ForumPosts.Add(p);
            db.SaveChanges();
        }
    }
