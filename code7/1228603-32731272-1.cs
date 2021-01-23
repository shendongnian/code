        public ActionResult Upload(HttpPostedFileBase file)
        {
            ImageGallery IG = new ImageGallery();
        IG.FileName = file.FileName;
          IG.ImageSize = file.ContentLength;
            byte[] data = new byte[file.ContentLength];
            file.InputStream.Read(data, 0, file.ContentLength);
               IG.ImageData = data;
            var model = new ImageViewModel
            {
                FileName = file.FileName,
                ImageSize = file.ContentLength,
                ImageData = data,
                File = file
            };
         
            using(MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.ImageGalleries.Add(IG);
                dc.SaveChanges();
            }
            return View(model);
    
        }
	}
