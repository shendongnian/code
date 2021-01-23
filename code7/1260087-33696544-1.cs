    // GET: Material
        [Authorize]
        public ActionResult Download(string file)
        {
            string path = Server.MapPath(String.Format("~/App_Data/Material/{0}", file));
            if(System.IO.File.Exists(path))
            {
                string mime = MimeMapping.GetMimeMapping(path);
                return File(path, mime);
            }
            return HttpNotFound();
        }   
