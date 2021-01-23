    [HttpPost]
    public ActionResult Index(MyModel m)
    {
        Request.InputStream.Position = 0;
                
        //the incoming request stream
        var requestStream = HttpContext.Request.InputStream;
    
        //the outgoing web request
        var webRequest = (HttpWebRequest)WebRequest.Create("http://yaddayadda/api/TargetApiController/Target");
    
        Stream webStream = null;
    
        try
        {
            //copy incoming request body to outgoing request
            if (requestStream != null && requestStream.Length > 0)
            {
                webRequest.Method = "POST";
                webRequest.ContentLength = requestStream.Length;
                webRequest.ContentType = "multipart/form-data";
                Stream stream = webRequest.GetRequestStream();
                requestStream.CopyTo(stream);
                stream.Close();
            }
        }
        finally
        {
            if (null != webStream)
            {
                webStream.Flush();
                webStream.Close();    // might need additional exception handling here
            }
        }
    
        using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
        {
            var result = response.StatusCode;
        }
    
    
        return View();
    }
