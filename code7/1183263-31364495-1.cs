    [XmlInclude(typeof(Bar))]
    [XmlRoot(ElementName ="Foo")]
    public class Foo : IFooInterface
    {
    	ObservableCollection<IBarInterface> barList;
    
    	[XmlElement(ElementName ="BarList")]
    	public ObservableCollection<Bar> XmlBarList
    	{
    		get
    		{
                // Creates an temporary Object, so it won't work
    			return this.BarList.Select(bar => bar as Bar).ToList();
    		}
    		set
    		{
    			 this.BarList = new ObservableCollection<IBarInterface>(value);
    		}
    	}
    
    	// Won't work out of the box with XmlSerializer
    	// so I Ignore it
    	[XmlIgnore]
    	ObservableCollection<IBarInterface> BarList
    	{
    		get
    		{
    			return this.barList;
    		}
    		set
    		{
    			this.barList = value;
    		}
    	}
    }
 
