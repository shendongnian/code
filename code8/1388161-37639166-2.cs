    while (true)
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://localhost:8080");
        request.Credentials = new NetworkCredential("anonymous", "");
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        // reuse the connection (not necessary, as the true is the default)
        request.KeepAlive = true;
    
        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        using (Stream responseStream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(responseStream))
        {
            Console.WriteLine(reader.ReadToEnd());
    
            reader.Close();
            response.Close();
        }
    }
