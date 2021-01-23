    public void Send(string url, string fileName, string content, string user, string password)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(content)
        var request = (FtpWebRequest) WebRequest.Create(new Uri(url + @"/" + fileName));
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.UsePassive = false;
        request.Credentials = new NetworkCredential(user, password);
        request.ContentLength = bytes.Length;
        var requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        var response = (FtpWebResponse) request.GetResponse();
        if (response != null) response.Close();
    }
