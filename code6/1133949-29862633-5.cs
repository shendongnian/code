	public ActionResult Create(PostCreateModel post)
	{
		if (post.uploadImage != null)
        {
            return RedirectToAction("Create");
        }
        byte[] imageData = null;
        using (var binaryReader = new BinaryReader(post.uploadImage.InputStream)) // not set to an instance of an object
        {
            imageData = binaryReader.ReadBytes(post.uploadImage.ContentLength);
        }
        var Image = new Post
        {
             Picture = imageData
        };
        post.Picture = Image.Picture;
