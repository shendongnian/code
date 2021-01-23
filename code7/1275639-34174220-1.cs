    using System.Reflection;        
    
    foreach (XrefObject x in xref_file)
    {
        _width = x.WIDTH;
        
    	PropertyInfo prop = 
            temp_signal.GetType()
                .GetProperty(x.DBU_FIELD, BindingFlags.Public | BindingFlags.Instance);
    	if(prop != null && prop.CanWrite)
    	{
    		prop.SetValue(temp_signal, _dba_line.Substring(_offset, _width).Trim(), null);
    	}
    	
        _offset += _width;
    }
