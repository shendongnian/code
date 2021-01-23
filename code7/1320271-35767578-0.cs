    var _request = (FtpWebRequest)WebRequest.Create(configuration.Url);
	_request.Method = WebRequestMethods.Ftp.DownloadFile;
	_request.Timeout = 20000;
	_request.Credentials = new NetworkCredential("auser", "apassword");
	_request.KeepAlive = false;
	_request.ServicePoint.ConnectionLeaseTimeout = 20000;
	_request.ServicePoint.MaxIdleTime = 20000;
	try
	{
		using (var _response = (FtpWebResponse)_request.GetResponse())
		using (var _responseStream = _response.GetResponseStream())
		using (var _streamReader = new StreamReader(_responseStream))
		{
			this.c_fileData = _streamReader.ReadToEnd();
		}
	}
	catch (Exception genericException)
	{
		throw genericException;
	}
	finally
	{
		_request.Abort();
	}
