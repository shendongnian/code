    public ActionResult Index(FotoModel model, HttpPostedFileBase file)
    {
      if (file != null)
            {
                byte[] empfile = new byte[file.ContentLength];
                file.InputStream.Read(empfile, 0, file.ContentLength);
                var Empdoc = System.Text.UnicodeEncoding.Default.GetString(empfile);
            }
    }
