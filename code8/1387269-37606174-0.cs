    public class XmlDataSerializer
    {
    	public string Serialize<T>(T objectValue) where T : class
    	{
    		var utf8WithoutBom = new UTF8Encoding(false);
    		var xmlSerializer = new XmlSerializer(typeof(T));
    
    		var xmlWriterSettings = new XmlWriterSettings
    		{
    			Indent = true,
    			Encoding = utf8WithoutBom
    		};
    
    		using (var memoryStream = new MemoryStream())
    		{
    			using (var writer = XmlWriter.Create(memoryStream, xmlWriterSettings))
    			{
    				xmlSerializer.Serialize(writer, objectValue);
    				return utf8WithoutBom.GetString(memoryStream.ToArray());
    			}
    		}
    	}
    
    	public T Deserialize<T>(string stringValue) where T : class
    	{
    		var xmlSerializer = new XmlSerializer(typeof(T));
    
    		//hacky way to get rid of BOM for all encodings
    		var xmlStart = stringValue.IndexOf("<?xml", StringComparison.Ordinal);
    		if (xmlStart > 0)
    		{
    			stringValue = stringValue.Remove(0, xmlStart);
    		}
    
    		using (var stringReader = new StringReader(stringValue))
    		{
    			using (var xmlReader = XmlReader.Create(stringReader))
    			{
    				return xmlSerializer.Deserialize(xmlReader) as T;
    			}
    		}
    	}
    }
