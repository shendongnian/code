    public void Upload(string uri, string filePath)
	{   
        string formdataTemplate = "Content-Disposition: form-data; filename=\"{0}\";\r\nContent-Type: image/jpeg\r\n\r\n";
        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
		request.ServicePoint.Expect100Continue = false;
		request.Method = "POST";
		request.ContentType = "multipart/form-data; boundary=" + boundary;
		
   		using(FileStream fileStream    = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, Path.GetFileName(filePath));   
                byte[] formbytes = Encoding.UTF8.GetBytes(formitem);
                requestStream.Write(formbytes, 0, formbytes.Length);
                byte[] buffer = new byte[1024 * 4];
                int bytesLeft = 0;
                
                while ((bytesLeft = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    requestStream.Write(buffer, 0, bytesLeft);
                }
                
            }
        }
        
        try
        {	        
            using (HttpWebResponse response    = (HttpWebResponse)request.GetResponse()) { }
            
            Console.WriteLine ("Success");
        }
        catch (Exception ex)
        {
            throw;
        }
    }
