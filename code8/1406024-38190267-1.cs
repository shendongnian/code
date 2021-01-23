    using System;
    using System.Text.RegularExpressions;
    using System.Text;
    
    namespace Rextester
    {
        public class Program
        {
            public static string replaceAsWithWhatever(string inputText)
            {
                StringBuilder sb = new StringBuilder();
                Regex rx = new Regex("as");
                
                int prior = 0;
                foreach (Match match in rx.Matches(inputText))
                {
                    int i = match.Index;
                    
                    // copy the text not matched in between
                    sb.Append(inputText.Substring(prior, i - prior));
                    // [optional] prepend some text before match 
                    sb.Append(" [before replacement] ");
                    // replace match with something, possibly permutation of match
                    sb.Append(" [replacement of " + match.ToString() + "] ");
                    // append text after match
                    sb.Append(" [after replacement] ");
                    
                    prior = i + match.Length;
                }
                // copy remaining string after all matches to stringbuilder
                sb.Append(inputText.Substring(prior, inputText.Length - prior));
                return sb.ToString();
            }
            
            public static void Main(string[] args)
            {
                // test cases
                Console.WriteLine(replaceAsWithWhatever("text before as between as whatever"));
                Console.WriteLine(replaceAsWithWhatever("sentence without matches"));
                Console.WriteLine(replaceAsWithWhatever("as"));
                Console.WriteLine(replaceAsWithWhatever("as ass ;)"));
            }
        }
    }
