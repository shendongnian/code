    public ActionResult MyAction(string FilePath)
            {
                try
                {
            FilePath = Path.Combine(Server.MapPath("~/Uploads/Videos/") + FilePath);
                                                                         
            byte[] myVideo = System.IO.File.ReadAllBytes(FilePath);
            return new FileContentResult(myVideo, "video/mp4");
                }
                catch (Exception)
                {
                    return View("_NotFoundVideo");
                }
    
    
            }
     
