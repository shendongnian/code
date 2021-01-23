    public static string AlphaSort( string s )
    {
      string sorted = string.Join( "" ,
                        ( s ?? "")
                        .Split()
                        .OrderBy( x => x )
                        ) ;
      return sorted ;
    }
