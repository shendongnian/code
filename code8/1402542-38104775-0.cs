    byte[] fileContent = fap.FileContent;
    string fileName = "fileName.pdf";
    string path = HttpContext.Current.Server.MapPath("~/App_Data/Files/");
    string pathAndFile = System.IO.Path.Combine(path, fileName);
    File.WriteAllBytes(pathAndFile, fileContent);
