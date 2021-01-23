	using System.Diagnostics;
	Stopwatch stopwatch = new Stopwatch();
	using (var writer = new StreamWriter(filename, true))
	{
		foreach (string website in lstWebSites)
		{
			for (var i = 0; i < 4; i++)
			{
			
				MyWebRequest request = new MyWebRequest();
				stopwatch.Start();
				request.Request();
				stopwatch.Stop();
				Console.WriteLine("Time elapse: {0}", stopwatch.Elapse);
				stopwatch.Restart();
			}
		}
	}
