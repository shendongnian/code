    string fileName = Request.QueryString["fileName"];
    string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
    WebClient client = new WebClient();
    Byte[] buffer = client.DownloadData(path);
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");
    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + fileName);
    HttpContext.Current.Response.BinaryWrite(buffer);
    HttpContext.Current.Response.End();
