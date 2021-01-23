    public string DownloadFile(string url, string filename)
	{
        var dirToSave = "C:/Directory/Test";
		if (!Directory.Exists(dirToSave))
			Directory.CreateDirectory(dirToSave);
		var localPath = String.Format("{0}\\{1}", dirToSave, filename);
		var client = new WebClient();
		client.Headers[HttpRequestHeader.Cookie] = CookieString();
		try
		{ client.DownloadFile(GetAbsoluteUrl(url), localPath); }
		catch (Exception ex)
		{ Assert.Fail("Error to download the file: " + ex); }
		return localPath;
	}
