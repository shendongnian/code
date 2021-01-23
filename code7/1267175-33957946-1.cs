    public ActionResult UploadTemporary(HttpPostedFileBase file)
    {
        Guid reference = Guid.NewGuid();
        string extension = Path.GetExtension(file.FileName);
        string fullName= reference.ToString()+extension;
        var path = Path.Combine(Server.MapPath("~/Content/TempFiles/"), fullName);
        var data = new byte[file.ContentLength];
        file.InputStream.Read(data, 0, file.ContentLength);
        using (var sw = new FileStream(path, FileMode.Create))
        {
            sw.Write(data, 0, data.Length);
        }
        return Content(reference);
    }
