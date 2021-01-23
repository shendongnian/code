	using System;
	using System.Net;
	public string m_FtpHost = "ftp://myftpserver.com";
	public string m_FtpUsername = "FTP username";
	public string m_FtpPassword = "FTP password";
	public void UploadFile(string filepath)
	{
		// Get an instance of WebClient
		WebClient client = new System.Net.WebClient();
		// parse the ftp host and file into a uri path for the upload
		Uri uri = new Uri(m_FtpHost + new FileInfo(filepath).Name);
		// set the username and password for the FTP server
		client.Credentials = new System.Net.NetworkCredential(m_FtpUsername, m_FtpPassword);
		// upload the file asynchronously, non-blocking.
		client.UploadFileAsync(uri, "STOR", filepath);
	}
