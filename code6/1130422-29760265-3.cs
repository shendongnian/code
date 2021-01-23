    public ActionResult Edit(int id)
    {
      Post post = db.Posts.Include(i => i.Tags).FirstOrDefault(i => i.Id == id); // First() will throw an exception is the item is not found
      if (post == null) { return HttpNotFound(); }
      PostViewModel model = new PostViewModel()
      {
        ID = post.ID,
        Title = post.Title,
        SelectedTags = post.Tags.Select(t => t.Id)
      }; // include UserId property?
      ConfigureEditModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(PostViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureEditModel(model);
        return View(model);
      }
      // map your view model to a data model, save it and redirect
    }
    private void ConfigureEditModel(PostViewModel model)
    {
      model.TagsList = new SelectList(db.Tags, "Id", "Name");
      model.UserList = new BlogUsers(db.Tags, "UserID", "Email"); // ??
    }
