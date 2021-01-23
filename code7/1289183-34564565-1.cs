    public List<string> ImagesString
    {
        get 
        {
            return Directory.EnumerateFiles(Server.MapPath("~/Content/Prop/" + FlatID + "/"))
                            .Select(fn => "~/Content/Prop/" + FlatID + "/" + Path.GetFileName(fn))
                            .ToList();
        }
    }
