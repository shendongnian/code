    public static IEnumerable<string> ListDirectory(string uri, NetworkCredential credentials)
    {
        var request = FtpWebRequest.Create(uri);
        request.Method = WebRequestMethods.Ftp.ListDirectory;
        request.Credentials = credentials;
        using (var response = (FtpWebResponse)request.GetResponse())
        using (var stream = response.GetResponseStream())
        using (var reader = new StreamReader(stream, true))
        {
            while (!reader.EndOfStream)
			    yield return reader.ReadLine();
        }
    }
