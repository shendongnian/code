    public bool DirectoryExists(string directory)
    {
      try
      {
        FtpWebRequest request = GetRequest(directory);
        request.Method = WebRequestMethods.Ftp.ListDirectory;
        return request.GetResponse() != null;
      }
      catch
      {
        return false;
      }
    }
