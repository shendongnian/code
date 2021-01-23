        public static long UploadFile(string FilePath, MultipartPartParser file)
        {           
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpURL + FilePath.Substring(1).Replace('\\', '/'));
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Credentials = new NetworkCredential(UserName, Password);
                Stream requestStream = ftpRequest.GetRequestStream();
                long fileSize = 0;
                Byte[] buffer = new Byte[buferSize];
                int bytesRead = file.Read(buffer, 0, buferSize);
                fileSize += bytesRead;
                while (bytesRead > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                    bytesRead = file.Read(buffer, 0, buferSize);
                    fileSize += bytesRead;
                }
                requestStream.Close();
                return fileSize;
            }
            catch (Exception)
            {
                return -1;
            }
        }
