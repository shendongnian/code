    public static bool isValidConnection(string url, string user, string password, ref string errorMessage = "")
    {
    	try {
    		FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
    		request.Method = WebRequestMethods.Ftp.ListDirectory;
    		request.Credentials = new NetworkCredential(user, password);
    		request.KeepAlive = false;
    		request.UsePassive = true;
    		FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    		response.Close();
    	} catch (WebException ex) {
    		errorMessage = ex.Message;
    		return false;
    	}
    	return true;
    }
