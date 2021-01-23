    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Net;
    using System.IO;
     public static int DownloadFtp(string filePath, string fileName, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = < <The full path where the file is to be created.>>, 
                //fileName = < <Name of the file to be created(Need not be the name of the file on FTP server).>> 
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
 
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
 
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
 
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return 0;
            }
            catch (Exception ex)
            {
                // Logging.WriteError(ex.Message + ex.StackTrace);
                // System.Windows.Forms.MessageBox.Show(ex.Message);
                return -2;
            }
        }
