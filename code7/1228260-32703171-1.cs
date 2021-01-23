    public string ReverseMapPath(string path)
    {
        string appPath = Server.MapPath("~");
        return string.Format("~{0}", path.Replace(appPath, "").Replace("\\", "/"));
    }
    ...
    
    imagesModel.ImageList.Add(ReverseMapPath(item));
