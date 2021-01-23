    [HttpPost]
    public ActionResult Create(PostViewModel model)
    {
       var p = new Post { Title = model.Title };
       //Assign other properties as needed (Ex : content etc)
       p.Tags = new List<Tag>();  
       var tags = db.Tags;
       foreach (var item in model.Tags)
       {
          var existingTag = tags.FirstOrDefault(f => f.Name == item);
          if (existingTag == null)
          {
            existingTag = new Tag {Name = item};
          }
          p.Tags.Add(existingTag);
        }
        db.Posts.Add(p);
        db.SaveChanges();
        return RedirectToAction("Index","Post");
    }
