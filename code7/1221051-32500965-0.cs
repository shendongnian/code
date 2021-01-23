    public interface IDoesSomething
    {
    	void fillRandomly(Random r);
    }
    public class QBoss
    {
    	public double mx1 { get; set; }
    	public double mx2 { get; set; }
    	public int mx3 { get; set; }
    
    	public object refType { get; set; }
    
    	public void fillRandomly(Random r)
    	{
    		FillRandom(GetProps(this), this, r);	
    	}
    }
    
    
    public static IEnumerable<PropertyInfo> GetProps(object blah)
    {
    	return blah.GetType().GetProperties();
    }
    
    public static void FillRandom(IEnumerable<PropertyInfo> obj, object onObj, Random r)
    {
    	Action<PropertyInfo, object> setVal = (prop, val) => { prop.SetValue(onObj, val); };
    	foreach (var o in obj)
    	{
    		if (!o.PropertyType.IsValueType)
    		{
    			if (r.Next() % 2 != 1)
    			{
    				var v = Activator.CreateInstance(o.PropertyType);
    				setVal(o, v);
    				var id = v as IDoesSomething;
    				if (id != null)
    					id.fillRandomly(r);
    			}
    		}
    		if (o.PropertyType == typeof(double))
    			setVal(o, r.NextDouble());
    		if (o.PropertyType == typeof(int))
    			setVal(o, (int)(r.NextDouble() * 100));
    		
    		//etc, etc
    	}
    }
