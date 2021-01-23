	static byte[] ReplaceAssemblyRef(MemoryStream stream)
	{
		byte[] buffer = stream.GetBuffer();
		byte[] search = new byte["System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a".Length * sizeof( char )];
		byte[] replace = new byte["System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a".Length * sizeof( char )];
		Buffer.BlockCopy( "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a".ToCharArray(), 0, search, 0, search.Length );
		Buffer.BlockCopy( "System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a".ToCharArray(), 0, replace, 0, replace.Length );
		IEnumerable<int> indicies = Enumerable.Range( 0, buffer.Length - search.Length + 1 );
		for( int i = 0; i < search.Length; i++ )
			indicies = indicies.Where( n => buffer[n + i] == search[i] ).ToArray();
		foreach( int i in indicies )
			Buffer.BlockCopy( replace, 0, buffer, i, replace.Length );
		return buffer;
	}
