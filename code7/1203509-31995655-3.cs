    public static string InsertChar( this string s , char c , int i )
    {
      StringBuilder sb = new StringBuilder( s.Length+1 ) ;
      return sb.Append( s , 0 , i ).Append( c ).Append( s , i , s.Length-i ) ;
    }
