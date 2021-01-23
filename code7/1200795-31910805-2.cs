    public HttpResponseMessage Download()
    {      
            var xmlString = "<xml><name>Some XML</name></xml>";            
            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StringContent(xmlString, Encoding.UTF8, "application/xml");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "test.xml"
            };
                        
            return result;
    }
