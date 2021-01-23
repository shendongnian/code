    public ActionResult GetFile(string id)
    {
        // imaging you have a class which maps id with full file path
        // like c:\downloads\files\myfile.pdf
        string filePath=myFileManager.IsFileExist(id);
        if
        {
            // also you need to pass file's content type string
            // you could store this string when user uploads files
            return File(filePath, myFileManager.GetContentType(id),
                 Path.GetFileName(filePath));
        }
        return HttpNotFound();
    }
