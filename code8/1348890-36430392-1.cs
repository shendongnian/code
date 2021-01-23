    public static IEnumerable<string> Trim( this IEnumerable<string> collection )
    {
    	foreach( var item in collection )
    	{
    		var stringProperties = item.GetType().GetProperties()
    					.Where( p => p.PropertyType == typeof( string ) );
    
    		foreach( var stringProperty in stringProperties )
    		{
    			var currentValue = (string)stringProperty.GetValue( item, null );
    
    			if( currentValue != null )
    				stringProperty.SetValue( item, currentValue.Trim(), null );
    		}
    	}
    	return collection;
    }
		
