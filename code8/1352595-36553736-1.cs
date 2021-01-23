            [HttpPost]
        public ActionResult TestImage(Models.Answer model)
        {
            var imageFiles = Request.Files;
            if (imageFiles != null && imageFiles.Count > 0)
            {
                HttpPostedFileBase imageFile = imageFiles[0];
                if (imageFile.ContentLength > 0)
                {
                    var image = new byte[imageFile.ContentLength];
                    imageFile.InputStream.Read(image, 0, imageFile.ContentLength);
                }
            }
            return View();
        }
