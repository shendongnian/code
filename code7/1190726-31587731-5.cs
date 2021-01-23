    foreach (Control ctl in tab.Controls)
    {
    	try
    	{
    		var typ = ctl.GetType();
    		var ctl_clone1 = Activator.CreateInstance(typ);
    		PropertyInfo[] controlProperties = typ.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    		foreach (PropertyInfo propInfo in controlProperties)
    		{
    			if (propInfo.CanWrite)
    			{
    				if (propInfo.Name != "WindowTarget")
    					propInfo.SetValue(ctl_clone1, propInfo.GetValue(ctl, null), null);
    			}
    		}
    		Control ctl_clone2 = (Control)ctl_clone1;
    		tab2.Controls.Add(ctl_clone2);
    	}
    	catch (Exception ex)
    	{	
    		throw ex;
    	}
    }
