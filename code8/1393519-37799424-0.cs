    using System;
    using System.Text.RegularExpressions;
    
    class Example 
    {
       static void Main() 
       {
          string text = "^25121261064300000000000387?;XXXXXXXXXXXXXXXX=25121261064338700000?";
          string pat = @"\;(.*)\=";
         
          Regex r = new Regex(pat, RegexOptions.IgnoreCase);
          
          Match m = r.Match(text);
          int matchCount = 0;
          while (m.Success) 
          {
             Console.WriteLine("Match"+ (++matchCount));
             for (int i = 1; i <= 2; i++) 
             {
                Group g = m.Groups[i];
                Console.WriteLine("Group"+i+"='" + g + "'");
                CaptureCollection cc = g.Captures;
                for (int j = 0; j < cc.Count; j++) 
                {
                   Capture c = cc[j];
                   System.Console.WriteLine("Capture"+j+"='" + c + "', Position="+c.Index);
                }
             }
             m = m.NextMatch();
          }
       }
    }
