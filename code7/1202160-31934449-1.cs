	public void CreateLog(string sLogInfo)
	{
		string sDestionation = null;
		string sFileName = DateTime.Now.ToString("yyyyMMdd") + "_log.txt";
		sDestionation = @"D:\Log\";
		var sFile = sDestionation + sFileName;
		if (!Directory.Exists(sDestionation))
		{
			Directory.CreateDirectory(sDestionation);
		}
		using (var oWriter = new StreamWriter(sFile, true))
			oWriter.WriteLine(DateTime.Now + ": " + sLogInfo.Trim());
	}
