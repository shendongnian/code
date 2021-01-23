    public void SendPDF(string url)
    {
        System.IO.FileInfo file = new System.IO.FileInfo(url);
        if (file.Exists)
        {
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(url);
            Response.AddHeader("content-disposition", "attachment; filename=" + Session["empcd"].ToString() + "-Quotation.pdf");
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(buffer);
            Response.End();
        }
    }
