    public void DownloadFile(string fileName)
     {
        FileInfo file = new FileInfo(@"D:\DOCS\"+fileName);
        Context.Response.Clear();
        Context.Response.ClearHeaders();
        Context.Response.ClearContent();
        Context.Response.AddHeader("Content-Disposition", "attachment;  filename=" + file.Name); Context.Response.AddHeader("Content-Length", file.Length.ToString());
        Context.Response.ContentType = "application/zip"; 
        Context.Response.Flush();
        Context.Response.TransmitFile(file.FullName);
        Context.Response.End();
    }
