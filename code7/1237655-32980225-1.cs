    public class MyItems
    {
    	public string Name { get; private set; }
    	
    	public string Locale { get; private set; }
    	
    	readonly Func<OtherThing> factory;
    
    	public static readonly MyItems Products = new MyItems("Products", "en-US", () => Config.Products);
    	public static readonly MyItems Food = new MyItems("Food", "en-GB", () => Config.FishAndChips);
    	
    	private MyItems(string name, string locale, Func<OtherThing> factory)
    	{
    		this.Name = name;
    		this.Locale = locale;
    		this.factory = factory;
    	}
    	
    	public OtherThing GetOtherThing() {
    		return factory();
    	}
    }
