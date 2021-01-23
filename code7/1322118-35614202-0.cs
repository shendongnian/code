    List<string> img = new List<string>();
        
    foreach (string s in Request.Files)
    {
        HttpPostedFile file = Request.Files[s];
        int fileSizeInBytes = file.ContentLength;
        string fileName = file.FileName;
        string fileExtension = "";
        
        if (!string.IsNullOrEmpty(fileName))
        {
            img.add(fileName);
            fileExtension = Path.GetExtension(fileName);
            file.SaveAs(filename);
        }
