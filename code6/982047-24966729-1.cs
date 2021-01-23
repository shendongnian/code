    List<string[ ]> entries = new List<string[ ]>( );
    using ( TextReader rdr = File.OpenText( "TextFile1.txt" ) )
    {
    	string line;
    	while ( ( line = rdr.ReadLine( ) ) != null )
    	{
    		string[ ] entry = line.Split( ',' );
    		entries.Add( entry );
    	}
    }
