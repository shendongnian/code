    public IHttpActionResult SomeAction()
    {
        switch(Request.Headers.Accept.ToString())
        {
            case "application/json":
                // Return the whole DTO with the image URI
                break;
    
            case "image/jpeg":
                // Build a response containing a StreamContent 
                // or ByteArrayContent
                break;
        }
    }
