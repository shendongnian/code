    [HttpPost]
    public ActionResult UploadImage(List<HttpPostedFileBase> files)
    {
        EntityDBContext db = new EntityDBContext();
        List<Image> uploadedImages = new List<Image>();
        foreach (var file in files)
        {
            if (file != null)
            {
                string imageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + imageName);
                byte[] pictureAsBytes = new byte[file.ContentLength];
                using (BinaryReader br = new BinaryReader(file.InputStream))
                {
                    pictureAsBytes = br.ReadBytes(file.ContentLength);
                }
                //Save to folder
                file.SaveAs(physicalPath);
                //Save new record in database
                Image img = new Image
                    {
                        ImageName = imageName;
                        ImageBytes = pictureAsBytes;
                    };
                uploadedImages.Add(img);
            }
        }
        db.Images.AddRange(uploadedImages);
        db.SaveChanges();
        return View("ShowImage", uploadedImages);
    }
