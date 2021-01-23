    var webClient = new WebClient();
    byte[] imageBytes = webClient.DownloadData("ftp://server/image.png");
    
    Response.Buffer = true;
    Response.Charset = "";
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.ContentType = "image/png";
    Response.AddHeader("content-disposition", "attachment;filename=Image.png");
    Response.BinaryWrite(imageBytes);
    Response.Flush();
    Response.End();
