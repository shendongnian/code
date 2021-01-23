    public IHttpActionResult GetSomething()
    {
        var reader = new StreamReader(Request.Body);
        reader.BaseStream.Seek(0, SeekOrigin.Begin); 
        var rawMessage = body.ReadToEnd();
        
        return Ok();
    }
