    // POST: News/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(NewsDto news, HttpPostedFileBase uploadImage)
    {
        if (ModelState.IsValid && uploadImage != null)
        {
            var imageData = byte[uploadImage.ContentLength];
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }
            
            var newsEntity = new New {
              Title = news.Title,
              Description = news.Description,
              Picture = new Picture()
              {
                  ImageData = imageData,
                  ContentType = contentType // I would get that from the HttpPostedFileBase
              }
            }
            
            // I always wrap my database connections in a using.
            using (var db = new DbContext()) {
              db.News.Add(newsEntity);
              db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        return View(news);
    }
