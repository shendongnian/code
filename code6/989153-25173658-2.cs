    public static string AlphaSort( string s )
    {
      char[] chars = s.ToCharArray() ;
      Array.Sort( chars ) ;
      int i = 0 ;
      while ( i < chars.Length && char.IsWhiteSpace(chars[i]) ) ++i ;
      string sorted = new string( chars , i , chars.Length-i ) ;
      return sorted ;
    }
