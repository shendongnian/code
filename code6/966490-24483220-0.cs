    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "[1] [apple] [market]";
                string s2 = "[2][toy]asdv[shop]sdvdsrdt";
                
                foreach(Match m in Regex.Matches(s, @"\[(.*?)\]"))
                {
                    Console.WriteLine(m.Groups[1]);
                }
    
                foreach (Match m in Regex.Matches(s2, @"\[(.*?)\]"))
                {
                    Console.WriteLine(m.Groups[1]);
                }
            }
        }
    }
    
    [OUTPUT]
    1
    apple
    market
    2
    toy
    shop
