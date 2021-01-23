    static class Program
        {
            /// <summary>
            ///  Regular expression built for C# on: Thu, Jul 3, 2014, 02:47:43 PM
            ///  Using Expresso Version: 3.0.4750, http://www.ultrapico.com
            ///  
            ///  A description of the regular expression:
            ///  
            ///  1.6
            ///      1
            ///      Any character
            ///      6
            ///  
            ///
            /// </summary>
            public static Regex regex = new Regex(
                  "1.6",
                RegexOptions.CultureInvariant
                | RegexOptions.Compiled
                );
    
    
            // This is the replacement string
            public static string regexReplace =
                  "hello";
            static void Main(string[] args)
            {
                string input = @"
    116,
    1e6
    ";
                string result = regex.Replace(input, regexReplace);
                Console.WriteLine(result);
            }
    
           
        }
