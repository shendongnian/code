    static string EncodeNonAsciiCharacters( string value )
    {
        StringBuilder sb = new StringBuilder();
        foreach( char c in value ) {
            if( c > 127 ) {
                // This character is too big for ASCII
                string encodedValue = "\\u" + ((int) c).ToString( "x4" );
                sb.Append( encodedValue );
            }
            else {
                sb.Append( c );
            }
        }
        return sb.ToString();
    }
    
    Console.WriteLine(EncodeNonAsciiCharacters("ಅ"));
    \u0c85
    Console.WriteLine(EncodeNonAsciiCharacters("ಇ"));
    \u0c87
