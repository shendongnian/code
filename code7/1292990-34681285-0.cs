    public void Parse(string[] Params)
    {
    	// Fetch our property that we are setting the value to
    	FieldInfo prop = this.GetType().GetField("IsExample");
    	ObjectPropertyBase obj;
    
    	// Get the value that is set
    	var value = prop.Value.GetValue(this);
    		
    	// If the value is null, then we create a new object property instance
    	if (value == null)
    		obj = ObjectPropertyBase.Create(prop.Value);
    	else
    		obj = (ObjectPropertyBase)value;
    
    	// Set Values
    	obj.SetValueFromParams(Params);
    	prop.SetValue(this, obj);
    }
