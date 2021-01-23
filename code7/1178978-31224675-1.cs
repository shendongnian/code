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
                string[] hex = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1011", "1110", "1111" };
                string input = "";
                string ainput = "";
                string output = "";
     
                input = "ffff:0000:ffff:ffff";
                ainput = Aggregating(input);
                output = string.Join("", ainput.ToCharArray().Select(x => x == ':' ? ":" : hex[int.Parse(x.ToString(), NumberStyles.HexNumber)]));
                Console.WriteLine("input : {0}, A input = {1}, output = {2}", input, ainput, output);
                input = "0000:0000:0000:ffff:0000:0000";
                ainput = Aggregating(input);
                output = string.Join("", ainput.ToCharArray().Select(x => x == ':' ? ":" : hex[int.Parse(x.ToString(), NumberStyles.HexNumber)]));
                Console.WriteLine("input : {0}, A input = {1}, output = {2}", input, ainput, output);
                input = "1234:0000:0000:0000:1212";
                ainput = Aggregating(input);
                output = string.Join("", ainput.ToCharArray().Select(x => x == ':' ? ":" : hex[int.Parse(x.ToString(), NumberStyles.HexNumber)]));
                Console.WriteLine("input : {0}, A input = {1}, output = {2}", input, ainput, output);
                Console.ReadLine();
            }
            static string Aggregating(string input)
            {
                List<string> results = new List<string>();
                string[] array = input.Split(new char[] { ':' });
                int zeroCount = 0;
                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] == "0000")
                    {
                        if (i == array.Length - 1)
                        {
                            if (zeroCount == 0) results.Add("0000");
                        }
                        else
                        {
                            zeroCount++;
                        }
                    }
                    else
                    {
                        if (zeroCount == 1) results.Add("0000");
                        results.Add(array[i]);
                        zeroCount = 0;
                    }
                }
                return string.Join(":",results);
            }
        }
    }
    ​
