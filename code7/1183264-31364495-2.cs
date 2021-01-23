    [XmlRoot(ElementName ="Bar")]
    public class Bar : IBarInterface
    {
    	string BarString;
    
    	[XmlElement(ElementName = "BarString")]
    	string BarString
    	{
    		get
    		{
    			return this.bar;
    		}
    		set
    		{
    			this.bar = value;
    		}
    	}
    }
