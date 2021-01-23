    public enum MyEnum
    {
    	Val1,
    	Val2,
    }
    
    public class TestDefine
    {
    	public string MyEnumPropSerialize
    	{
    		get
    		{
    			if (MyEnumProp.HasValue)
    			{
    				return MyEnumProp.ToString();
    			}
    			return null;
    		}
    		set
    		{
    			MyEnum importValue;
    			if (Enum.TryParse<MyEnum>(value, out importValue))
    			{
    				MyEnumProp = importValue;
    			}else
    			{
    				MyEnumProp.ToString();
    			}
    		}
    	}
    
    	[XmlIgnore]
    	public MyEnum? MyEnumProp { get; set; }
    }
