    void Main()
    {	
        string fileName = @"C:\Test\image.jpg";
        string uri = @"http://localhost/Upload/File";
        string contentType = "image/jpeg";
    
        Http.Upload(uri, fileName, contentType);
    }
    
    public static class Http
    {
        public static void Upload(string uri, string filePath, string contentType)
        {
            string boundary         = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes    = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            
            string formdataTemplate = "Content-Disposition: form-data; name=file; filename=\"{0}\";\r\nContent-Type: {1}\r\n\r\n";
            string formitem         = string.Format(formdataTemplate, Path.GetFileName(filePath), contentType);
            byte[] formBytes        = Encoding.UTF8.GetBytes(formitem);
    
        
    
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
    
    
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    requestStream.Write(formBytes, 0, formBytes.Length);
    
                    byte[] buffer = new byte[1024*4];
                    int bytesLeft;
    
                    while ((bytesLeft = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        requestStream.Write(buffer, 0, bytesLeft);
                    }
    
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                }
            }
    
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                }
    
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
