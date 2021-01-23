    public class LoaderSingleton
    {
    	private static readonly LoaderSingleton _instance = new LoaderSingleton();
    	private List<DataRow> _items;
    	static LoaderSingleton()
    	{
    
    	}
    
    	private LoaderSingleton()
    	{
    
    	}
    
    	public static LoaderSingleton Instance
    	{
    		get
    		{
    			return _instance;
    		}
    	}
    
    	public List<DataRow> Items
    	{
    		get
    		{
    			if (this._items == null)
    			{
    				this.Load();
    			}
    
    			return this._items;
    		}
    	}
    
    	public void Load()
    	{
    		this._items = //perform load from database
    	}
    }
