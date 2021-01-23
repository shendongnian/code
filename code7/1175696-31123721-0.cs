    public class baseType
    {
    	public string P { get { return "A"; }}
    }
    
    public class child : baseType
    {
    	new public string P { get { return "B"; }}
    }
    
    public static object GetBasePropValue(object src, string propName)
    {
    	return src.GetType().BaseType.GetProperty(propName).GetValue(src, null);
    }
    
    public static object GetPropValue(object src, string propName)
    {
    	return src.GetType().GetProperty(propName).GetValue(src, null);
    }
    
    void Main()
    {
    	var x = GetPropValue(new child(), "P");
    	var y = GetBasePropValue(new child(), "P");
    }
