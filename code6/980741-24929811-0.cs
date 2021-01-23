    using System;
    using System.Text.RegularExpressions;
    
    class Example
    {
       static void Main()
       {
          string text = "One car red car blue car";
          // This regex will match the pattern you're looking for
          string pat = @"--\s\*\<\d{3}\>";
    
          // Instantiate the regular expression object.
          Regex r = new Regex(pat, RegexOptions.IgnoreCase);
    
          // Match the regular expression pattern against a text string.
          Match m = r.Match(text);
          while (m.Success) 
          {
             // Do something ...
             // Find next match
             m = m.NextMatch();
          }
       }
    }
