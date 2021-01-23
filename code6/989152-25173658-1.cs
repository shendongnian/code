    public static string AlphaSort( string s )
    {
      string sorted = new string(
                        (s ?? "")
                        .Where( c => !char.IsWhiteSpace(c) )
                        .OrderBy( c => c )
                        );
      return sorted ;
    }
