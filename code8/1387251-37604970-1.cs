	var fileName = "";
	var workingProxies = new List<string>();
	Parallel.ForEach(
		File.ReadLines(fileName),
		() => new List<string>(),
		(line, state, bucket) =>
		{
			String[] addressParts = line.Split(':');
			try
			{
				WebClient wc = new WebClient();
				wc.Proxy = new WebProxy(addressParts[0], Int32.Parse(addressParts[1]));
				wc.DownloadString("http://google.com/ncr");
				
				bucket.Add(line);
			}
			catch { }
			return bucket;
		},
		subBucket =>
		{
			lock(workingProxies)
				workingProxies.AddRange(subBucket);
		}
	);
	//Now read from workingProxies
