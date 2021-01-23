    // Download the file
	//Console.WriteLine("Downloading \"{0}\" from {1}...", node.Name, Config.FTP_HOST + "/" + node.DirectoryFileIsIn);
	FtpWebRequest request = CreateRequest("ftp://" + Config.FTP_HOST + "/" + node.DirectoryFileIsIn + "/" + node.Name, WebRequestMethods.Ftp.DownloadFile.ToString());
	FtpWebResponse response = (FtpWebResponse)request.GetResponse();
	Stream responseStream = response.GetResponseStream();
	FileStream filestream = new FileStream(new_path, FileMode.Create);
	// Start stopwatch for calculating download speed
	Stopwatch stopwatch = new Stopwatch();
	stopwatch.Start();
	// Read/write downloaded bytes
	int chunkSize = 1024;
	long total = node.FileSize;
	int streamPosition = 0;
	while (true)
	{
		byte[] buffer = new byte[Math.Min(chunkSize, node.FileSize - streamPosition)];
		//byte[] buffer = new byte[chunkSize];
		int readBytes = responseStream.Read(buffer, 0, buffer.Length);
		if (readBytes == 0)
			break;
		currentFileSizeDownloaded += readBytes; // total bytes downloaded
		streamPosition += readBytes; // for tracking response stream position
		filestream.Write(buffer, 0, readBytes);
	}
	// Stop the stopwatch
	stopwatch.Stop();
	secondsElapsed += stopwatch.Elapsed.TotalSeconds;
	filestream.Flush();
	//Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
	response.Dispose();
	filestream.Dispose();
	response.Close();
	filestream.Close();
	}
