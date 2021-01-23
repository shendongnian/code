    string inputPath = "<input.txt file path>";
    string outputPath = "<output.txt file path>";
    for (int iterator = 0; iterator < 10000; iterator++)
    {
	    bool exists = false;
	    long startTimeMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
	    while (!exists)
	    {
		    if (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startTimeMillis >= 5 * 60 * 1000) Environment.Exit(0);
		    if (File.Exists(inputPath))
		    {
			    exists = true;
			    FileStream f = File.Open(inputPath, FileMode.Open);
			    String output = String.Empty;
			    for (int i = 0; i < f.Length; i++)
			    {
				    output += (char)f.ReadByte();
			    }
			    f.Dispose();
			    File.WriteAllText(outputPath, output);
			    File.Delete(inputPath);
		    }
	    }
    }
    Environment.Exit(0);
