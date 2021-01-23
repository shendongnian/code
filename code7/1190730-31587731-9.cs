    foreach (Control ctl in tab1.Controls)
    {
    	try
    	{
    		if (ctl != null)
    		{
    			object obj_clone = CloneObject(ctl);
    			if (obj_clone != null && obj_clone is Control)
    			{
    				Control ctl_clone = (Control)CloneObject(ctl);
    				tab2.Controls.Add(ctl_clone);
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		Debug.WriteLine("Exception: " + ex.Message + " - TargetSite:" + ex.TargetSite + " - Source: " + ex.Source + " - InnerException: " + ex.InnerException.Message.ToString());
    	}
    }
    
    private Object CloneObject(Object obj)
    {
    	var typ = obj.GetType();
    	var obj_clone = CreateInstanceOfType(typ);
    	PropertyInfo[] controlProperties = typ.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    	foreach (PropertyInfo propInfo in controlProperties)
    	{
    		if (propInfo.CanWrite && propInfo.Name != "WindowTarget")
    		{
    			try
    			{
    				if (propInfo.PropertyType.IsValueType || propInfo.PropertyType.IsEnum || propInfo.PropertyType.Equals(typeof(System.String)))
    				{
    					propInfo.SetValue(obj_clone, propInfo.GetValue(obj));
    				}
    				else
    				{
    					object value = propInfo.GetValue(obj);
    					if (value == null)
    						propInfo.SetValue(obj_clone, null);
    					else
    						propInfo.SetValue(obj_clone, CloneObject(value));
    				}
    			}
    			catch (Exception ex)
    			{
    				Debug.WriteLine("Exception: " + ex.Message + " - TargetSite:" + ex.TargetSite + " - Source: " + ex.Source + " - InnerException: " + ex.InnerException.Message.ToString());
    			}
    		}
    	}
    	return (Object)obj_clone;
    }
    
    public object CreateInstanceOfType(Type type)
    {
        // First make an instance of the type.
        object instance = null;
    
        // If there is an empty constructor, call that.
        if (type.GetConstructor(Type.EmptyTypes) != null)
            instance = Activator.CreateInstance(type);
        else
        {
            // Otherwise get the first available constructor and fill in some default values.
            // (we are trying to set all properties anyway so it shouldn't be much of a problem).
            ConstructorInfo ci = type.GetConstructors()[0];
            ParameterInfo[] parameters = ci.GetParameters();
    
            object[] ciParams = new object[parameters.Length];
    
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].DefaultValue != null)
                {
                    ciParams[i] = parameters[i].DefaultValue;
                    continue;
                }
    
                Type paramType = parameters[i].ParameterType;
                ciParams[i] = CreateInstanceOfType(paramType);
            }
    
            instance = ci.Invoke(ciParams);
        }
    
        return instance;
    }
