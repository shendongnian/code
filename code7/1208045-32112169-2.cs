    DateTime now = DateTime.UtcNow;
    string logString = now.ToString("yyyyMMddHHmmss");
    
    byte[] logEntry;
    int elements = logString.Length / 2;
    logEntry = new byte[elements];
    
    for (int i = 0; i < elements; i++)
    {
    	logEntry[i] = Convert.ToByte(logString.Substring(i * 2, 2));
    }
    
    Console.WriteLine(logString);
    Console.WriteLine();
    for (int i = 0; i < elements; i++)
    {
	Console.WriteLine("{0}: {1:00}", i, logEntry[i]);
    }
