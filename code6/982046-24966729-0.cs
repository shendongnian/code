    List<string[ ]> entries = new List<string[ ]>( );
    using ( FileStream fs = File.OpenRead( "TextFile1.txt" ) )
    using ( TextReader rdr = new StreamReader( fs ) )
    {
    	while ( fs.Position < fs.Length - 1 )
    	{
    		string[ ] entry = rdr.ReadLine( ).Split( ',' );
    		entries.Add( entry );
    	}
    }
