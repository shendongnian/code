	using System;
	using System.Net;
	public string m_FtpHost = "ftp://myftpserver.com"
	public string m_FtpUsername = "FTP username"
	public string m_FtpPassword = "FTP password"
	public void UploadFile(string filepath)
	{
		WebClient client = new System.Net.WebClient()
		Uri uri = new Uri(m_FtpHost + new FileInfo(filepath).Name);
		client.Credentials = new System.Net.NetworkCredential(m_FtpUsername, m_FtpPassword);
		client.UploadFileAsync(uri, "STOR", filepath)
	}
