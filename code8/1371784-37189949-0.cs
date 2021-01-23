    public void UploadFTPTextFile(string ftpServer, string ftpFolder, string user, string passward, string NName, FileUpload FileUpload1)
    {
        string fileName = NName;
        byte[] fileBytes = File.ReadAllBytes(fileName);
    
        //Create FTP Request.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + ftpFolder + fileName);
        request.Method = WebRequestMethods.Ftp.UploadFile;
    
        request.Credentials = new NetworkCredential(user, passward);
        request.ContentLength = fileBytes.Length;
        request.UsePassive = true;
        request.UseBinary = true;
        request.ServicePoint.ConnectionLimit = fileBytes.Length;
        request.EnableSsl = false;
    
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileBytes, 0, fileBytes.Length);
            requestStream.Close();
        }
    }
