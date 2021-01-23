    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL);
    
    request.ContentType = "application/pdf;charset=UTF-8";
    request.Method = "GET";
    
    using(HttpWebResponse response = (HttpWebResponse) request.GetResponse()) {
    
        BinaryReader bin = new BinaryReader(response.GetResponseStream());
    
        byte[] buffer = bin.ReadBytes((Int32) response.ContentLength);
    
        Response.Buffer = true;
        Response.Charset = "";
    
        Response.AppendHeader("Content-Disposition", "attachment; filename=+ filename); 
    
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
        Response.ContentType = "application/pdf";
    
        Response.BinaryWrite(buffer);
    
        Response.Flush();
    
        Response.End();
    }
