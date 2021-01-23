    public static T ConvertTo<T>( this DataRow dataRow, string columnName )
    {
	    var defaultValue = default( T );
        var valueOfCell = GetCellValue(dataRow, columnName);
        if ( defaultValue == null && valueOfCell == null )
	    {
		    return default( T );
	    }
	    try
	    {
            return ( T )Convert.ChangeType( valueOfCell, typeof( T ) );
	    }
	    catch ( InvalidCastException ex )
	    {
		    return default( T );
	    }
    }
