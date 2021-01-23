    List<List<string>> dataCollection = new List<string>();
    List<string> rowCollection;
    
    while ( reader.Read() )
    {
    	rowCollection = new List<string>();
    	for ( int i = 0; i < reader.FieldCount; i++ )
    	{
    		rowCollection.Add( Convert.ToString( reader[i] ) );
    	}
    	dataCollection.add(rowCollection);
    }
