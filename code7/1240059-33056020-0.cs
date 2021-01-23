    static void Main(string[] args)
    {
      string path = @"C:\FileWrite_Append\SomeFile.txt";
    
      if (!System.IO.File.Exists(path))
      {
        WriteAndOrAppendText(path, "Text");
      }
      else if (System.IO.File.Exists(path))
      {
        WriteAndOrAppendText(path, "Another Text");             
      }
    }
    private static void WriteAndOrAppendText(string path, string strText)
    {
    	if (!File.Exists(path))
    	{
    		StreamWriter fileStream = new StreamWriter(path, true);
    		fileStream.WriteLine(strText);
    		fileStream.Flush();
    		fileStream.Close();
    	}
    	else
    	{
    		StreamWriter fileStream2 = new StreamWriter(path, true);
    		fileStream2.WriteLine(strText);
    		fileStream2.Flush();
    		fileStream2.Close();
    	}
    }
