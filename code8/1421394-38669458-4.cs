    using System;
    using System.Text.RegularExpressions;
 
    class ConfigParser
    {
        public string Text { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Date { get; set; }
        public ConfigParser(string text)
        {
            Text =text;
            Parse(text);
        }
       
        private static string pattern = @"
         ^FirstName=(?<firstname>\w+)    \|          
         LastName=(?<lastname>\w+)       \|              
         UserId=(?<userid>\w+)           \|                  
         Password=(?<pasword>.+)        
         Date=(?<date>.+)                         
         $
        ";
        private Regex regex = new Regex(pattern,
               RegexOptions.Singleline
               | RegexOptions.ExplicitCapture
               | RegexOptions.CultureInvariant
               | RegexOptions.IgnorePatternWhitespace
               | RegexOptions.Compiled
               );
        private void Parse(string text)
        {
            Console.WriteLine("text: {0}",text);
            Match m = regex.Match(text);
            FirstName = m.Groups["firstname"].ToString();
            LastName = m.Groups["lastname"].ToString();
            UserId = m.Groups["userid"].ToString();
            Password = m.Groups["pasword"].ToString();
            Date = m.Groups["date"].ToString();
            
        }
    }
 
