    // Operates on a UTF-8 encoded text file
    using (var stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite))
    {
    	const int size = 4096;
    	var buffer = new byte[size];
    	int count; 
    	while ((count = stream.Read(buffer, 0, size)) > 0)
    	{
    		var changed = false;
    		for (int i = 0; i < count; i++)
    		{
    			// obliterate all bytes that are not encoded characters between ␠ and ␡ 
    			if (buffer[i] < ' ' | buffer[i] > '\x7f')
    			{
    				buffer[i] = (byte)' ';
    				changed = true;
    			}
    		}
    		if (changed)
    		{
    			stream.Seek(-count, SeekOrigin.Current);
    			stream.Write(buffer, 0, count);
    		}
    	}
    }
