    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    namespace ConsoleTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = "ABC 12.23-22-22-11|-ABC 33.20-ABC 44.00-ABC 11.00|ABC 12.23-22-22-11|-ABC 33.20-ABC 44.00-ABC11.00|ABC 12.23-22-22-11|-ABC 33.20-ABC 44.00-ABC 11.00";
                var pattern = "([^|]|[|][-])+[|]?";
                Match m;
    
                m = Regex.Match(input, pattern);
                while (m.Success) {
                    Debug.WriteLine(String.Format("Match from {0} for {1} characters", m.Index, m.Length));
                    Debug.WriteLine(input.Substring(m.Index, m.Length));
                    m = m.NextMatch();
                }
            }
        }
    }
