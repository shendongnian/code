    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                var picture = new Picture()
                {
                    hash = 0,
                    image = imageData,
                    width = 0,
                    height = 0
                };
                db.Pictures.Add(picture); // make sure that the picture was tracked by the EF
                news.picture = picture;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }
