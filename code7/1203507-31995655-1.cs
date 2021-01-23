    unsafe public static string InsertChar( this string s , char c , int i )
    {
      if ( s == null ) throw new ArgumentNullException("s");
      if ( i < 0 || i > s.Length ) throw new ArgumentOutOfRangeException("i");
      
      char[] buf = new char[s.Length+1];
      
      fixed ( char *src = s )
      fixed ( char *tgt = buf )
      {
        int j = 0 ; // offset in source
        int k = 0 ; // offset in target
        
        while ( j < i )
        {
          tgt[k++] = src[j++];
        }
        
        tgt[k++] = c ;
        
        while ( j < s.Length )
        {
          tgt[k++] = src[j++] ;
        }
        
      }
      
      return new string( buf ) ;
    }
