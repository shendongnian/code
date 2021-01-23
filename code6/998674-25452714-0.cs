    public static void TrimTrailingBytes( this byte[] buffer , byte trimValue )
    {
      int i = buffer.Length ;
      
      while ( i > 0 && buffer[--i] == trimValue )
      {
        ; // no-op by design
      }
      
      Array.Resize( ref buffer , i+1 ) ;
      
      return ;
    }
