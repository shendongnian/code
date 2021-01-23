    using System;
    using System.Text.RegularExpressions;
    
    namespace RegexTest
    {
        class Program
        {
            static void Main(string[] args) {
                string pattern = @"(?<=>)[^<]+(?=<)";
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                string example = @"<?xml version=""1.0""><student><name>Peter</name><age>21</age><interests count=""3""><interest>Games</interest><interest>C#</interest>";
                MatchCollection results = rgx.Matches(example);
                foreach (Match m in results)
                {
                    Console.WriteLine(m.Value);
                }
            }
        }
    }
