    public static string CombineFilesText(string mainPath, string clientPath)
    {
    	string returnText = ReadTextFile(mainPath);
    	returnText += ReadTextFile(clientPath);
    
    	return returnText;
    }
    
    private static string ReadTextFile(string filePath)
    {
    	using (FileStream stream = File.OpenRead(filePath))
    	{
    		using (StreamReader reader = new StreamReader(stream))
    		{
    			return reader.ReadToEnd();
    		}
    	}
    }
