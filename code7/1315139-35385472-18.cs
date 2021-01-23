    [HttpPost]
    public IActionResult Create(CreatePost model)
    {
        //Create an object of your entity class and map property values
        var post=new Post() { ImageCaption = model.ImageCaption };
        if (model.MyImage != null)
        {
           post.Image =  GetByteArrayFromImage(model.MyImage);
        }
        _context.Posts.Add(post);
        _context.SaveChanges();
        return RedirectToAction("Index","Home");
    }
