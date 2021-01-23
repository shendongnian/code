    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase file)
    {
        BinaryReader b = new BinaryReader(file.InputStream);
        byte[] binData = b.ReadBytes((int)file.InputStream.Length);
    }
