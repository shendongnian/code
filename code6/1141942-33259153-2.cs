    public MyClass DeserializeJsonFile(string path)
    {
    	try
    	{
    		using (StreamReader r = new StreamReader(path))
    		{
    			string json = r.ReadToEnd();
    			return JsonConvert.DeserializeObject<MyClass>(json);
    		}
    	}
    	catch (Exception ex)
    	{		
    		this.log.Error("Error deserializing  jsonfile. FilePath: {0}", ex, path);
    		return null;                
    	}
    }
