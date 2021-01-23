    public void delete(string deleteFile) {
      try {
        // using over IDisposable is 
        using (var ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile)) {
          ftpRequest.Credentials = new NetworkCredential(user, pass);
          // When in doubt, use these options 
          ftpRequest.UseBinary = true;
          ftpRequest.UsePassive = true;
          ftpRequest.KeepAlive = true;
          // Specify the Type of FTP Request 
          ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
          // Establish Return Communication with the FTP Server 
          ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
        }
      }
      catch (WebException ex) {
        Console.WriteLine(ex.ToString());
      }
    }
