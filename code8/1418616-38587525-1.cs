    // Create array for holding request in bytes
    byte[] inputStream = new byte[HttpContext.Current.Request.ContentLength];
    
    // Read the entire request input stream
    HttpContext.Current.Request.InputStream.Read(inputStream, 0, inputStream.Length);
    
    // Set stream position back to beginning
    HttpContext.Current.Request.InputStream.Position = 0;
    
    // Get the XML request
    string xmlRequestString = Encoding.UTF8.GetString(inputStream);
    
