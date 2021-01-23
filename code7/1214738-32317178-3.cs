        using System;
        using System.Text.RegularExpressions;
    
        public class Test
        {
            public static void Main()
            {
                var regex = new Regex("(struct|class|interface)");
                var match = regex.Match("Hello, this contains a classic car");
                if (match.Success)
                {
                    Console.WriteLine(match.Index);
                }
            }
        }
