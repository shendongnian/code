    var webClient = new WebClient();
    byte[] imageBytes = webClient.DownloadData("ftp://server/image.png");
    
    context.Response.Buffer = true;
    context.Response.Charset = "";
    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    context.Response.ContentType = "image/png";
    context.Response.AddHeader("content-disposition", "attachment;filename=Image.png");
    context.Response.BinaryWrite(imageBytes);
    
