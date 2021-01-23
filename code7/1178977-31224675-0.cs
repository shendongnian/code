    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] hex = {"0000","0001","0010","0011","0100","0101","0110","0111","1000","1001","1010","1011","1100","1011","1110","1111"};
                string input = "ffff:0000:ffff:ffff";
                var output = string.Join("", input.ToCharArray().Select(x => x == ':' ? ":" : hex[int.Parse(x.ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture)]));
                
            }
        }
    }​
