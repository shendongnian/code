    /// <summary>
    /// Upload HttpPostedFileBase to ftp server
    /// </summary>
    /// <param name="image">type of HttpPostedFileBase</param>
    /// <param name="targetpath">folders path in ftp server</param>
    /// <param name="source">jpeg image name</param>
    public static void UploadFileToFTP(HttpPostedFileBase image,string targetpath,string source) {
        string ftpurl = ConfigurationManager.AppSettings["Ftp_Images_Domain"];
        string ftpusername = ConfigurationManager.AppSettings["Ftp_Images_Usr"];
        string ftppassword = ConfigurationManager.AppSettings["Ftp_Images_Pwd"]; 
        try {
            SetMethodRequiresCWD();
			
            string ftpfullpath = ftpurl + targetpath + source;
			
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
            ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            using ( Stream ftpstream = ftp.GetRequestStream() )
				image.InputStream.CopyTo(ftpstream)
        } catch (WebException e) {
            String status = ((FtpWebResponse)e.Response).StatusDescription;
        }
    }
	
