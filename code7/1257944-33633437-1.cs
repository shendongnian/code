    string path = @"C:\SomePath\Name.txt";
    if (!System.IO.File.Exists(path))
    {
        WriteAndOrAppendText(path, "File Created");
    }
    else if (System.IO.File.Exists(path))
    {
        WriteAndOrAppendText(path, "New Boot.");             
    }
    private static void WriteAndOrAppendText(string path, string strText)
    {
    	if (!File.Exists(path))
    	{
    		using (StreamWriter fileStream = new StreamWriter(path, true))
    		{
    			fileStream.WriteLine(strText);
    			fileStream.Flush();
    			fileStream.Close();
    		}
    	}
    	else
    	{
    		using (StreamWriter fileStream2 = new StreamWriter(path, true))
    		{
    			fileStream2.WriteLine(strText);
    			fileStream2.Flush();
    			fileStream2.Close();
    		}
    	}
    }
