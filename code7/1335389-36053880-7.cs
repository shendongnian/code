    [HttpPost]
    public ActionResult Upload(List<VideoVM> model)
    {
        foreach(VideoVM video in model)
        {
            if (video.File.ContentLength > 0)
            {
                continue;
            }
            string fileName = Path.GetFileName(video.File.FileName);
            string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            video.File.SaveAs(path);
            Video dataModel = new Video()
            {
                Title = video.Title,
                Description = video.Description,
                ....
                Path = path
            };
            db.Videos.Add(dataModel);
        }
        db.SaveChanges();
        return RedirectToAction("UploadedVideos");
    }
