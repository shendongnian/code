    static IEnumerable<Token> Tokenize( string s )
    {
      StringBuilder sb = new StringBuilder() ;
      int i = 0 ;
      while ( i < s.Length )
      {
        // gobble and return a punctuation token, if there is one.
        sb.Length = 0 ;
        while ( i < s.Length && !char.IsLetterOrDigit(s[i]) )
        {
          sb.Append(s[i++]) ;
        }
        if ( sb.Length > 0 ) yield return new Token{ Type = TokenType.NonWord , Text = sb.ToString() , } ;
        
        // gobble the next word and return it.
        sb.Length = 0 ;
        while ( i < s.Length && char.IsLetterOrDigit( s[i] ) )
        {
          sb.Append( s[i++] ) ;
        }
        if ( sb.Length > 0 ) yield return new Token{ Type = TokenType.Word , Text = sb.ToString() , } ;
      }
    }
