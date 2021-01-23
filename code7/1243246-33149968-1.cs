    PropertyInfo[] props = typeof(gridRecord).GetProperties();
    foreach(PropertyInfo prop in props) 
    {
    	object[] attrs = prop.GetCustomAttributes(true);
    	foreach(object attr in attrs) 
        {
    		AuthorAttribute authAttr = attr as AuthorAttribute;
    		if (authAttr != null) 
            {
    			string propName = prop.Name;
    			string auth = authAttr.Name;
    		}
    	}
    }
