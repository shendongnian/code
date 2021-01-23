    public void CombineUDAs( ObservableCollection<Tuple<object, object>> UDAs )
    {
    	foreach ( var item in UDAs )
    		foreach ( var innerItem in UDAs.Where( innerItem => innerItem != innerItem && item.Item1 == innerItem.Item1 ) )
    			Console.WriteLine( "Value is same: {0}", item.Item2 == innerItem.Item2 );
    }
