        ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 ;
        using (WebDownloadClient wc = new WebDownloadClient())
        {
            wc.Headers.Add("Content-Encoding", "gzip");
            wc.Headers.Add("Accept-Encoding", "gzip, compress");
            wc.DownloadFile(url, fileName);
        }
    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
        if (error == System.Net.Security.SslPolicyErrors.None)
        {
            return true;
        }
        return false;
    }
