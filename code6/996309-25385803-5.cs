    private ResponseFileInfo GetFile(string fileName)
    {
        string requestId = Guid.NewGuid().ToString().ToUpper();
        string uriTemplate = String.Format("https://www.myDomain.com/grabfile/grabfile.svc/file/myapp/?q={0}&rid={1}&sid={2}",fileName,requestId,this.sid);
    
        MemoryStream fileContent = null;
        string fileName = String.Empty;
        Uri uri = new Uri(uriTemplate);
        using (WebRequest webRequest = WebRequest.Create(uri))
        {
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                fileName = webResponse.Headers["Content-Disposition"].Replace("attachment; filename=", String.Empty).Replace("\"", String.Empty);
                fileContent = new MemoryStream();
                Stream responseStream = webResponse.GetResponseStream();
                byte[] responseBuffer = new byte[16*1024];
                int responseBytesRead;
                while((responseBytesRead = responseStream.Read(responseBuffer, 0, responseBuffer.Length) > 0)
                    fileContent.Write(responseBuffer, 0, responseBytesRead);
            }
        }
    
        return new ResponseFileInfo(fileName, fileContent);
    }
