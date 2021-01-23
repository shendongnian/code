    public HttpResponseMessage Download()
    {      
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);        
        var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
               
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = string.Format("test.xml")
                };
            }
       result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
       return result;
    }
