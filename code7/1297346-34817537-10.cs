    public ActionResult Download(int[] photoIds)
    {
        var attachments = new List<string>();
        foreach (var photo in db.Photos.Where(p => photoIds.Contains(p.Id)))
        {
            attachments.Add(Server.MapPath(photo.imageUrl));
        }
        return new ZipFileResult(attachments.ToArray())
        {
            FileDownloadName = string.Format("Photos-{0:yyyyMMdd-HHmm}.zip",
                DateTime.Now)
        };
    }
