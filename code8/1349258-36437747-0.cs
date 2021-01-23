	class MaskDictionary
	{
	    // ... properties ...
	    
	    public string ToString(string format)
	    {
	        string val = format;
	        foreach (PropertyInfo property in typeof(MaskDictionary).GetProperties())
	        {
	            val = val.Replace("{" + property.Name + "}", property.GetValue(this).ToString());
	        }
	        return val;
	    }
	}
