    public override int Read(byte[] buffer, int offset, int count)
    {
    	lock(_stream)
    	{
    		//position the inner stream to end of last read (another consumer may have moved it)
    		_stream.Seek(Position, SeekOrigin.Begin);
    
    		//read the bytes, up to count
    		var count = _stream.Read(buffer, offset, count);
    
    		//update the next read position
    		Position += count;
    
    		return count;
    	}
    }
    
    public override long Position{get;set;}
