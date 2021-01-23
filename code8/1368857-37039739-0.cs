    public static Stream OpenWavStream(string path)
    	{
    		var stream = new FileStream(path, FileMode.Open);
    		stream.Seek(44, SeekOrigin.Current);
        	return stream;
    	}
    
    public static void UseWaveStream()
    	{
    		try
    		{
    			using(Stream thisStream = OpenWavStream("C:\\myfile.txt"))
    			{
    				 // do whatever 
    			}
    		}
    		catch(Exception ex)
    		{
    			Console.WriteLine(ex.ToString());
    		}
    	}
    	
	
