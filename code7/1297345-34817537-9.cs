    public ActionResult Download(List<int> photoIds)
    {
        var attachments = new List<string>();
        foreach (int photoId in photoIds)
        {
            var Photo = db.Photos.Find(photoId);
            attachments.Add(Server.MapPath(Photo.imageUrl));
        }
        return new ZipFileResult(attachments.ToArray())
        {
            FileDownloadName = string.Format("Photos-{0:yyyyMMdd-HHmm}.zip",
                DateTime.Now)
        };
    }
