    var fileName = "";
    var workingProxies = new List<string>();
	Parallel.ForEach(
		File.ReadLines(fileName),
		line =>
		{
			String[] addressParts = line.Split(':');
			try
			{
				WebClient wc = new WebClient();
				wc.Proxy = new WebProxy(addressParts[0], Int32.Parse(addressParts[1]));
				wc.DownloadString("http://google.com/ncr");
				
				lock (workingProxies)
					workingProxies.Add(line);
			}
			catch { }
		}
	);
