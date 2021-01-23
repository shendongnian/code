        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                    using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        var buffer = new byte[1024];
                        int count;
                        while ((count = file.InputStream.Read(buffer, 0, 1024)) > 0)
                        {
                            fs.Write(buffer, 0, count);
                        }
                    }
                    FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    TileService.TileServiceClient client = new TileService.TileServiceClient();
                    client.Open();
                    client.UploadFile(fileName, fsSource);
                    client.Close();
                    fsSource.Dispose();
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
            }
            return RedirectToAction("");
        }
