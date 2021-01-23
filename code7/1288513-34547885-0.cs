    public static bool UploadFile(string FilePath, HttpPostedFileBase file)
    {
        try
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create(ftpURL + FilePath);
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.Credentials = new NetworkCredential(UserName, Password);
            ftpRequest.ContentLength = file.ContentLength;
            using (Stream requestStream = ftpRequest.GetRequestStream())
            {
                file.InputStream.CopyTo(requestStream);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
