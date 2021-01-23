    using (MyWebClient client = new MyWebClient())
    {
      client.Timeout = 1200000;
	  byte[] data = client.DownloadData(url);
	  File.WriteAllBytes(localFile, data);    
    }
