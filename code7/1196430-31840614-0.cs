    int numberOfStreams = 4;
    List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
    string fileName = @"C:\MyCoolFile.txt";
    //Ranges list populated here
    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(fileName, FileMode.OpenOrCreate, null, fileSize.Value, MemoryMappedFileAccess.ReadWrite))
    {
	    Parallel.For(0, numberOfStreams, index =>
	    {
	        try
	        {
	            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("Some URL");
	            using(Stream responseStream = webRequest.GetResponse().GetResponseStream())
	            {
	                using (MemoryMappedViewStream fileStream = mmf.CreateViewStream(ranges[index].Item1, ranges[index].Item2 - ranges[index].Item1 + 1, MemoryMappedFileAccess.Write))
	                {
	                    responseStream.CopyTo(fileStream);
	                }
	            };
	        }
	        catch (Exception e)
	        {
	            exception = e;
	        }
	    });
    }
