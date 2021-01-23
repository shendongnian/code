    public static SqlBytes BinaryDecompress(SqlBytes input)
    {
      if (input.IsNull)
        return SqlBytes.Null;
    
    	var outputStream = new MemoryStream();
    	using (MemoryStream result = new MemoryStream())
    	{
    		using (DeflateStream deflateStream =  new DeflateStream(input.Stream, CompressionMode.Decompress))
    		{
    			deflateStream.CopyTo(outputStream);
    		}
    	} 
      
    	outputStream.Position = 0;
    	return new SqlBytes (outputStream);
      
    }
