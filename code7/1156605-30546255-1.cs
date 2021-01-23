    public class Item
    {
    	public bool val { get; set; }
    	
    	public bool ShouldSerializeval()
        {
           return !val2;
        }
    	
    	[XmlElement(ElementName = "val2")]
    	public bool val2 { get; set; }	
    }
    
    void Main()
    {
    	Item item = new Item(){val=true, val2=true};
    	
    	XmlSerializer xs = new XmlSerializer(typeof(Item));
    	StringWriter sw = new StringWriter();
    	xs.Serialize(sw, item);
    	sw.ToString();
    }
