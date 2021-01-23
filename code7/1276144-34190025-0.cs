    public static class StringExtensions
    {
      public static string Truncate( this string s , int maxLength )
      {
        if ( s == null ) throw new ArgumentNullException("s");
        if ( maxLength < 0 ) throw new ArgumentOutOfRangeException("maxLength");
        return s.Length <= maxLength ? s : s.Substring(0,maxLength);
      }
    }
