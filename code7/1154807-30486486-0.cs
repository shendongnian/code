    public class Requirement
    {
        public RequirementType Type { get; set; }
    	
    	private object _value;
    	public object Value 
    	{ 
    		get { return _value; }
    		set
    		{
    			if (Type == RequirementType.OS && 
    				value.GetType() == typeof(OSType))
    			{
    				_value = value;
    			}
    			else 
    			{
    				throw new Exception("Value type is incorrect for Type provided");
    			}
    		}
    	}  
    }
