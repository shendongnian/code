    public void SendFiletoBrowser(string path,string fileName)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                using (FileStream fs = File.OpenRead(Server.MapPath(path)))
                {
                    fs.CopyTo(ms);
                }
                ms.Position = 0;
                OpenInBrowser(ms, fileName);
            }
            catch (Exception)
            {
                    
                throw;
            }
            
    
        }
    
        public void OpenRemoteFileInBrowser(Uri destinationUrl, string fileName)
        {
            try
            {
                WebClient wc = new WebClient();
                using (MemoryStream stream = new MemoryStream(wc.DownloadData(destinationUrl.ToString())))
                {
                    OpenInBrowser(stream, fileName);
                }
            }
            catch (Exception)
            {
                    
                throw;
            }
            
        }
    
        private void OpenInBrowser(MemoryStream stream, string fileName)
        {
            
            byte[] buffer = new byte[4 * 1024];
            int bytesRead;
            bytesRead = stream.Read(buffer, 0, buffer.Length);
    
            Response.Buffer = false;
            Response.BufferOutput = false;
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
            if (stream.Length != -1)
                Response.AppendHeader("Content-Length", stream.Length.ToString());
    
            while (bytesRead > 0 && Response.IsClientConnected)
            {
                Response.OutputStream.Write(buffer, 0, bytesRead);
                bytesRead = stream.Read(buffer, 0, buffer.Length);
            }
    
        }
