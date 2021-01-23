    public enum TokenType
    {
      Word    = 1 ,
      NonWord = 2 ,
    }
     
    public class Token
    {
        
      public TokenType Type { get ; set ; }
      public string    Text { get ; set ; }
        
      // This helps in viewing instances in the debugger
      public override string ToString()
      {
        return string.Format( "{0}:{1}" , Type,Text ) ;
      }
        
    }
