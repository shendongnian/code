    private void DownloadFM()
    {
        try
        {
            //Get the file byte array from DB.
            byte[] bytes = GetFileBytesFromDB();
            string fileName = "DownloadedFile.txt";
    
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
    
            string contentDisposition;
            if (Request.Browser.Browser == "IE")
                contentDisposition = "attachment; filename=" + Uri.EscapeDataString(templateName);
            else
            {
                contentDisposition = "attachment; filename*=UTF-8''" + Uri.EscapeDataString(templateName);
            }
            Response.AddHeader("Content-Disposition", contentDisposition);
            Response.AddHeader("Content-Length", bytes.Length.ToString());
            Response.AddHeader("X-Download-Options", "noopen");
            Response.ContentType = "application/octet-stream";
            Response.OutputStream.Write(buff, 0, buff.Length);
            Response.Flush();
            Response.Close();
            Return;
        }
        catch (Exception ex)
        {
            //Log error message to DB
        }
    }
