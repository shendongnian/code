    if (file != null && file.ContentLength > 0)
    {
        var extension = Path.GetExtension(file.FileName)
        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
        var path = Path.Combine(Server.MapPath("~/App_Data/uploads/slides"), fileName);
    
        for (int i = 1; System.IO.File.Exists(path); i++)
            path = Path.Combine(Server.MapPath("~/App_Data/uploads/slides"), fileName + "_" + i.ToString() + extension);
    
        file.SaveAs(path);
    
        model.Image = path;
    }
