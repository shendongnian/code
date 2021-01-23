    string physicalPath = Server.MapPath(filePath);
    if (System.IO.File.Exists(physicalPath))
    {
      // do stuff
    }
    else
    {
      // handle error
    }
