    public static JObject ReadJson(string file_path)
    {	
    	StreamReader file = null;
    	try {
    		JObject o1 = JObject.Parse(File.ReadAllText(file_path));
    		file = File.OpenText(file_path);
    		using (JsonTextReader reader = new JsonTextReader(file))
    		{
    			return (JObject)JToken.ReadFrom(reader);
    		}
    	}
    	catch
    	{
    		return default(JObject);
    	}
    	//dispose "file" when exiting the method
    	finally
    	{
    		if(file != null)
    			file.Dispose();
    	}
    }
