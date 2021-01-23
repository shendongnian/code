    using System;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
               String abc = "<a href='http://someserver/some url/somepage.htm?param+1=test'>Some link</a>";
               string pattern = @"=['""]([\s\S])+['""]";
               Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
               Match match = rgx.Match(abc);
               if (match.Success)
               {
                   
                   abc=abc.Replace(match.Value,match.Value.Replace(" ","%"));
               }
               Console.WriteLine(abc);
            }
        }
    }
