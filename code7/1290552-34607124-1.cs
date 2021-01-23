    public ActionResult DownloadFile(string strData) {
        var cd = new System.Net.Mime.ContentDisposition { FileName = "test.rar", Inline = false };
        byte[] arr = System.IO.File.ReadAllBytes(@"G:\test.rar");
        
        Response.ContentType = "application/x-rar-compressed";
        Response.AddHeader("content-disposition", cd.ToString());
        Response.Buffer = true;
        Response.Clear();
        Response.BinaryWrite(arr);
        Response.End();
        
        return new FileStreamResult(Response.OutputStream, Response.ContentType);
    }
