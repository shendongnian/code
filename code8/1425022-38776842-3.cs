     class RegParser
    {
        public string FileNmae { get; set; }
        public string Doc { get; set; }
        public string Txt { get; set; }      
 
      
       
        private static string pattern = @"
		Replace
		\(
		(?<filename>\w+)
		\,\s*
		\u0022                # double quote
		\.
		(?<txt>\w+)
		\u0022
		,\s*
		\u0022
		\.
		(?<doc>\w+)		
     ";			
        private Regex regex = new Regex(pattern,
               RegexOptions.Singleline
               | RegexOptions.ExplicitCapture
               | RegexOptions.CultureInvariant
               | RegexOptions.IgnorePatternWhitespace
               | RegexOptions.Compiled
               );
        public void Parse(string text)
        {
            Console.WriteLine("text: {0}",text);
            Match m = regex.Match(text);
            FileNmae = m.Groups["filename"].ToString();
            Doc = m.Groups["doc"].ToString();
            Txt = m.Groups["txt"].ToString();        
        }
    }  
