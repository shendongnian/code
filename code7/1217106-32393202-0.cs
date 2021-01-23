    public interface IValueHolder
    {
    	object Value {get; set;}
    }
    
    public class IsWalkable : Attribute, IValueHolder
    {
    	public object Value {get; set;}
    	public IsWalkable(bool value)
    	{
    		Value = value;
    	}
    }
    
    public class IsBuildSpace : Attribute, IValueHolder
    {
    	public object Value {get; set;}
    	public IsBuildSpace(bool value)
    	{
    		Value = value;
    	}
    }
    
    public enum Zone
    {
    	None,
    	Arable,
    }
    
    public class ZoneType : Attribute, IValueHolder
    {
    	public object Value {get; set;}
    	public ZoneType(Zone value)
    	{
    		Value = value;
    	}
    }
        
    public class TileGraphicIndex : Attribute, IValueHolder
    {
    	public object Value {get; set;}
    	public TileGraphicIndex(int value)
    	{
    		Value = value;
    	}
    }
    
    public class TileAttributeCollector
    {
    	protected readonly Dictionary<string, object> _attrs;
    
    	public object this[string key]
    	{
    		get
    		{
    			if (_attrs.ContainsKey(key)) return _attrs[key];
    			else return null;
    		}
    		
    		set
    		{
    			if (_attrs.ContainsKey(key)) _attrs[key] = value;
    			else _attrs.Add(key, value);
    		}
    	}
    	
    	public TileAttributeCollector()
    	{
    		_attrs = new Dictionary<string, object>();
    
    		Attribute[] attrs = Attribute.GetCustomAttributes(this.GetType()); 
            foreach (Attribute attr in attrs)
            {
    			IValueHolder vAttr = attr as IValueHolder;
    			if (vAttr != null)
    			{
    				this[vAttr.ToString()]= vAttr.Value;
    			}
            }
    	}
    }
    
    [IsWalkable(true), IsBuildSpace(false), ZoneType(Zone.Arable), TileGraphicIndex(2)]
    public class FarmTile : TileAttributeCollector
    {
    }
