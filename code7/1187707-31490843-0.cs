    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string prefix = "abc";
                string suffix = "xyz";
                string pattern = string.Format("{0}.*{1}", prefix, suffix);
                string input = "abc123456789xyz";
                bool resutls = Regex.IsMatch(input, pattern);
            }
        }
    }
    ​
