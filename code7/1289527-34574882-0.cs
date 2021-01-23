    static void CompressFile()
    {
    	string fileIn = @"D:\sin2.txt";
    	string fileOut = @"D:\sin2.txt.pgz";
    	using (var input = File.OpenRead(fileIn))
    	using (var output = new GZipStream(File.Create(fileOut), CompressionMode.Compress))
    		Write(input, output);
    }
    
    static void DecompressFile()
    {
    	string fileIn = @"D:\sin2.txt.pgz";
    	string fileOut = @"D:\sin2.1.txt";
    	using (var input = new GZipStream(File.OpenRead(fileIn), CompressionMode.Decompress))
    	using (var output = File.Create(fileOut))
    		Write(input, output);
    }
    
    static void Write(Stream input, Stream output, int bufferSize = 10 * 1024 * 1024)
    {
    	var buffer = new byte[bufferSize];
    	for (int readCount; (readCount = input.Read(buffer, 0, buffer.Length)) > 0;)
    		output.Write(buffer, 0, readCount);
    }
 
