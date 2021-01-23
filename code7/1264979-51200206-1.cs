    public string UploadFile()
    {
        string sRetVal = string.Empty;
        string sFullDestination = this.DestinatinFullIDPath + this.UpLoadFileName;
        try
        {
            if ((this.CreateDestinationDir(this.DestinatinFullModulePath) == true) &
                (this.CreateDestinationDir(this.DestinatinFullIDPath) == true))
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(sFullDestination);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Credentials = new NetworkCredential(this.UserName, this.Password);
                ftpRequest.UsePassive = true;
                ftpRequest.UseBinary = true;
                ftpRequest.EnableSsl = false;
                byte[] fileContents;
                using (BinaryReader binReader = new BinaryReader(File.OpenRead(this.UpLoadFullName)))
                {
                    FileInfo fi = new FileInfo(this.UpLoadFullName);
                    binReader.BaseStream.Position = 0;
                    fileContents = binReader.ReadBytes((int)fi.Length);
                }
                ftpRequest.ContentLength = fileContents.Length;
                using (Stream requestStream = ftpRequest.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    sRetVal = string.Format("Upload File Complete, status {0}", response.StatusDescription);
                }
            }
        }
        catch (WebException ex)
        {
            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
        }
        return sRetVal;
    }
 
