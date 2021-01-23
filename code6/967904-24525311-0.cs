    class Xml
    {
    	public static string Serialize(object objectToSerialize)
    	{
    		var mem = new MemoryStream();
    		var ser = new XmlSerializer(objectToSerialize.GetType());
    		ser.Serialize(mem, objectToSerialize);
    		var ascii = new UTF8Encoding();
    		return ascii.GetString(mem.ToArray());
    	}
    	public static string ToFile(object objectToSerialize, string filename)
    	{
    		try
    		{
    			var s = Serialize(objectToSerialize);
    			File.WriteAllText(filename, s);
    			return s;
    		}
    		catch (Exception e)
    		{
    			return null;
    		}
    	}
    }
