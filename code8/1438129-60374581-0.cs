    WebRequest request = WebRequest.Create("http://www.foo.bar/binary.file");
    using (WebResponse response = request.GetResponse())
    {
        var responseStream = response.GetResponseStream();
    
        using (var memoryStream = new MemoryStream())
        {
            responseStream.CopyTo(memoryStream);
            // This one is important so we can read the stream from the beginning.
            memoryStream.Seek(0, SeekOrigin.Begin); 
    
            // Perform my first thing.
            var isValid = Utility.ValidateContent(memoryStream);
    
            if (isValid)
            {
                // Reset the position to the beginning of the stream again
                memoryStream.Seek(0, SeekOrigin.Begin); 
                using (var fileStream = File.Create("c:\\temp\\myfile.ext"))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
