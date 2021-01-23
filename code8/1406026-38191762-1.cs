    using System;
    using System.Text.RegularExpressions;
    using System.Text;
    
    /* Basically a context-free replacement, minus the infinite words */
    namespace Rextester
    {
        public class Program
        {
            public static string replace(string inputText, Regex find, string replacement)
            {
                // to avoid a situation like the following: replace ass with assassin in string ass
                // "ass" -> "assassin" -> "assassinassin" -> etc.
                // it is only allowed to match after the last match in the replacement
                // aka. if we were to replace "ass" with "assassin a" in string "assss" we'd get           
                // "ass" -> "assassin ass" -> "assassin aassassin a"
                int countToSkipInReplacement = 0;
                int minimumIndex = 0;
                
                Match m;
                
                // first check if the replacement contains matches as well
                m = find.Match(replacement);
                if (m.Success)
                {
                    while (m.Success)
                    {
                        countToSkipInReplacement = m.Index + 1;
                        m = m.NextMatch();
                    } 
                }
                
                while(true)
                {
                    // uncomment to see all forms in between
                    //Console.WriteLine(inputText);
                    
                    // find a match
                    m = find.Match(inputText);
                    
                    // skip until the minimum index is found
                    while (m.Success && m.Index < minimumIndex)
                        m = m.NextMatch();
                    
                    // if it has no further matches, return current string
                    if (!m.Success)
                        return inputText;
     
                    // glue a new inputText together with the contents before, the replacements and whatever comes after
                    inputText = inputText.Substring(0, m.Index) + 
                                replacement + 
                                inputText.Substring(m.Index + m.Length, inputText.Length - (m.Index + m.Length));
                    
                    // make sure it doesn't go back and replace the text it just inserted again.
                    minimumIndex = m.Index + countToSkipInReplacement;
                }
            }
            
            public static void Main(string[] args)
            {
                Regex rx = new Regex("as");
                
                Console.WriteLine(replace("text before ass between as whatever", rx, "a"));
                Console.WriteLine(replace("sentence without matches", rx, "a"));
                Console.WriteLine(replace("as", rx, "a"));
                Console.WriteLine(replace("as", rx, "as"));
                Console.WriteLine(replace("assss", rx, "ba"));
            }
        }
    }
