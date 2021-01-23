	class MaskDictionary
	{
	    // ... properties ...
		[DisplayName("bar")]
	    public string foo {get;set;}
	    public int baz {get;set;}
	    
	    public string ToString(string format)
	    {
	        string val = format;
	        foreach (PropertyInfo property in typeof(MaskDictionary).GetProperties())
	        {
	        	var dispAttr = (DisplayNameAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute));
	        	string pName = dispAttr != null ? dispAttr.DisplayName : property.Name;
	            val = val.Replace("{" + pName + "}", property.GetValue(this).ToString());
	        }
	        return val;
	    }
	}
