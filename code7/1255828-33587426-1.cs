    [DataContract]
    public class MyNameValueInfoSurrogate 
    {
            //string is serializable so we'll just copy this property back and forth
    	[DataMember(Order = 1)]
    	public string Name { get; set; } 
    
            //byte[] is serializable so we'll need to convert object to byte[] and back again
    	[DataMember(Order = 2)]
    	public byte[] Value { get; set; }
    
    	public static implicit operator MyNameValueInfo(MyNameValueInfoSuggorage suggorage)
    	{
    		return suggorage == null ? null : new MyNameValueInfo
    		{
    			Name = suggorage.Name,
    			Value = Deserialize(suggorage.Value)
    		};
    	}
    
    	public static implicit operator MyNameValueInfoSuggorage(MyNameValueInfo source)
    	{
    		return source == null ? null : new MyNameValueInfoSuggorage
    		{
    			Name = source.Name,
    			Value = Serialize(source.Value)
    		};
    	}
    
    	private static byte[] Serialize(object o)
    	{
    		if (o == null)
    			return null;
    
    		using (var ms = new MemoryStream())
    		{
    			var formatter = new BinaryFormatter();
    			formatter.Serialize(ms, o);
    			return ms.ToArray();
    		}
    	}
    
    	private static object Deserialize(byte[] b)
    	{
    		if (b == null)
    			return null;
    			
    		using (var ms = new MemoryStream(b))
    		{
    			var formatter = new BinaryFormatter();
    			return formatter.Deserialize(ms);
    		}
    	}
    }
