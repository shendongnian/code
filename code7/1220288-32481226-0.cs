    ftp.Method = WebRequestMethods.Ftp.ListDirectory;
    string hex = string.Empty;
    using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
    using (Stream stream = response.GetResponseStream())
    {
        int b;
        while ((b = stream.ReadByte()) >= 0)
        {
            hex += b.ToString("X2") + ",";
        }
    }
