    for (int i = 0; i < Request.Files.Count; i++)
    {
        string ext = (Path.GetExtension(Request.Files[i].FileName));
        string docName = Request.Files[i].FileName.Replace(ext, "");
        int fileSize = sizes[i];
        // save to database etc...
    }
