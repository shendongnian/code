    public static FileStream WaitForFile(string fullName)
    {
    	FileStream fs = null;
    	int numTries = 0;
    	while (true)
    	{
    		++numTries;
    		try
    		{
    			//try to open the file
    			fs = new FileStream(fullName, FileMode.Open, FileAccess.Read, FileShare.None, 100);
    
    			fs.ReadByte();//if it's open, you can read it
    			fs.Seek(0, SeekOrigin.Begin);//Since you read one byte, you should move the cursor position to the begining.                    
    			break;
    		}
    		catch (Exception ex)
    		{
    			if (numTries > 10)//try 10 times
    			{
    				return fs;//Or you can throw exception
    			}
    			System.Threading.Thread.Sleep(10000);//wait 
    		}
    	}
    	return fs;
    }
