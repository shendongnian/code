    static IEnumerable<Token> Tokenize( string s )
    {
      Regex rx = new Regex( @"(?<word>\w+)|(?<nonword>\W+)" , RegexOptions.IgnoreCase ) ;
      return rx
             .Matches( s )
             .Cast<Match>()
             .Select( m => new Token {
               Type = m.Groups["word"].Success ? TokenType.Word         : TokenType.NonWord         ,
               Text = m.Groups["word"].Success ? m.Groups["word"].Value : m.Groups["nonword"].Value ,
             }) ;
    }
