    public class Test
    {
    	public static void UploadFileToFTP()
    	{
    
    		string ftpurl = "ftp://ServerName:21/test.txt";
    
    		try
    		{
    			string filename = "F:\\testing.txt";
    			string ftpfullpath = ftpurl;
    			FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
    			ftp.Credentials = new NetworkCredential();
    
    			//ftp.KeepAlive = false;
    			ftp.UsePassive = false;
    			ftp.Method = WebRequestMethods.Ftp.UploadFile;
    			byte[] myFile = File.ReadAllBytes(filename);
    			ftp.ContentLength = myFile.Length;
    			Stream ftpstream = ftp.GetRequestStream();
    			ftpstream.Write(myFile, 0, myFile.Length);
    			ftpstream.Close();
    			ftpstream.Flush();
    		}
    		catch (WebException e)
    		{
    			String status = ((FtpWebResponse)e.Response).StatusDescription;
    		}
    	}
    }
