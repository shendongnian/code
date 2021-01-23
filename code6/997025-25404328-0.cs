    public static void DownloadFile(string FilePath, System.Web.HttpResponse response)
    {
        System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
        if ((file.Exists))
        {
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            response.AddHeader("Content-Length", file.Length.ToString());
            response.ContentType = "application/octet-stream";
            response.WriteFile(file.FullName);
            response.End();
            response.Close();
            file = null;
        }
    }
