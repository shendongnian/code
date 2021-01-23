    public virtual ActionResult Image(string id)
    {
        string s = id.Substring(0, id.IndexOf(".")); // a "." is now required
        Guid guid = Guid.Parse(s);
        FileItem picture = FileService.GetItem(guid);
        return picture != null ? File(picture.FileData, picture.ContentType) : null;
    }
