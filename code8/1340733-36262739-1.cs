    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
    	ArrayList properties = new ArrayList();
    	foreach (DictionaryEntry e in _dictionary)
    	{
    		Attribute[] attrs;
    		if (PropertyAttributes == null || !PropertyAttributes.TryGetValue(e.Key.ToString(), out attrs))
    			attrs = null;
    		properties.Add(new DictionaryPropertyDescriptor(_dictionary, e.Key, attrs));
    	}
    
    	PropertyDescriptor[] props =
    		(PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));
    
    	return new PropertyDescriptorCollection(props);
    }
