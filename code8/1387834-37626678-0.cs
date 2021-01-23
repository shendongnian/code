    public ActionResult UploadPicture(Picture picture)
        {
            foreach (var file in picture.Files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(path);
                }
            }            
            return View();
        }
