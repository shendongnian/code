    public static string InsertChar( this string s , char c , int i )
    {
      
      // create a buffer of the desired length
      int len = s.Length + 1 ;
      StringBuilder sb = new StringBuilder( len ) ;
      sb.Length = len ;
      
      int j = 0 ; // pointer to sb
      int k = 0 ; // pointer to s
      
      // copy the prefix to the buffer
      while ( k < i )
      {
        sb[j++] = s[k++] ;
      }
      
      // copy the desired char to the buffer
      sb[j++] = c ;
      
      // copy the suffix to the buffer
      while ( k < s.Length )
      {
        sb[j++] = s[k++] ;
      }
      
      // stringify it
      return sb.ToString();
    }
