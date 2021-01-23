    public static class HtmlConstants
    {
      public const string Br = @"<br />";
    }
    public string CreateLineBreaker(int howManyLines)
    {
       string result = String.Empty;
       StringBuilder sb = new StringBuilder();
       if(howManyLines>0){
         for(int i=0;i<howManyLines;i++)
          { 
           sb.Append(HtmlConstants.Br);
          }
       result = sb.ToString();
                         }
      return result;
    }
     
