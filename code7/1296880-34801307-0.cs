    using System;
    using System.Linq;
    public class Test
    {
        public static void Main()
        {
            string str = "The Quick Brown Fox Jumps";
            string result = "";
            var tokens = str.Split(' ');
            
            for(int i = 0; i < tokens.Length - 1; i += 1) {
                result += tokens[i] + ' ' + tokens[i + 1] + "\n";
            }
            Console.WriteLine(result);
        }
    }
