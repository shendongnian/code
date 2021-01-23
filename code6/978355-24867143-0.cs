    public byte[] DownloadData(string path)
    {
        // Get the object used to communicate with the server.
        WebClient request = new WebClient();
         
        // Logon to the server using username + password
        request.Credentials = new NetworkCredential(Username, Password);
        return request.DownloadData(BuildServerUri(path));
    }
     
