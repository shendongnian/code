    static byte[] TrimTrailingBytes( byte[] buffer , byte trimValue )
    {
      int i = buffer.Length ;
      
      while ( i > 0 && buffer[--i] == trimValue )
      {
        ; // no-op by design
      }
      
      byte[] resized = new byte[i+1] ;
      Array.Copy( buffer , resized , resized.Length ) ;
      
      return resized ;
    }
