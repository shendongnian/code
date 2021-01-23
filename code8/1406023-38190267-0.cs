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
                    
                    sb.Append(inputText.Substring(prior, i - prior));
                    sb.Append(" [before replacement] ");
                    sb.Append(" [replacement of " + match.ToString() + "] ");
                    sb.Append(" [after replacement] ");
                    
                    prior = i + match.Length;
              
                }
                sb.Append(inputText.Substring(prior, inputText.Length - prior));
                return sb.ToString();
            }
            
            public static void Main(string[] args)
            {
                Console.WriteLine(replaceAsWithWhatever("text before as between as whatever"));
                Console.WriteLine(replaceAsWithWhatever("sentence without matches"));
                Console.WriteLine(replaceAsWithWhatever("as"));
                Console.WriteLine(replaceAsWithWhatever("as ass ;)"));
            }
        }
    }
