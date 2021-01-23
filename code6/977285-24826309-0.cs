    void Main()
    {
    	Serialize(new ToSerialize());
    	Serialize(new ToSerialize2());
    }
    
    private void Serialize(object o)
    {
    	var serializer = new XmlSerializer(o.GetType());
    	
    	var ms = new MemoryStream();
    	serializer.Serialize(ms, o);
    	
    	Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
    }
    
    public class ToSerialize2
    {
    	public ToSerialize2()
    	{
    		this.Other = new Other();
    	}
    
    	public Other Other { get; set; }
    }
    
    public class ToSerialize
    {
    	public readonly Other Other = new Other();
    }
    
    public class Other
    {
    }
