    static int Main( string[] argv )
    {
      string src = "The quick brown fox, who was named Fred, jumped over a lazy Dog (named Suzy) chasing a squirrel." ;
      List<Token> tokens = new List<Token>( Tokenize( src ) ) ;
      
      int i = 0 ;
      int j = tokens.Count - 1 ;
      
      // loop, reversing words as we go.
      while ( i < j )
      {
        Token left  = tokens[i] ;
        Token right = tokens[j] ;
        
        if ( left.Type  != TokenType.Word ) { ++i ; continue ; }
        if ( right.Type != TokenType.Word ) { --j ; continue ; }
        
        // at this point, we have two words: swap them
        tokens[i++] = right     ;
        tokens[j--] = left      ;
        
      }
      
      // Finally, put everything back together
      string rev = tokens
                   .Aggregate( new StringBuilder() , (b,t) => b.Append(t.Text) )
                   .ToString()
                   ;
      // Et, Voila!
      Console.WriteLine( "src: {0}" , src ) ;
      Console.WriteLine( "rev: {0}" , rev ) ;
      
      return 0 ;
    }
