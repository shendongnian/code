    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> output = new List<int>();
                string input = "1111011058108161105811110";
                for(int i = 0; i < input.Length; i += 5)
                {
                    output.Add(int.Parse(input.Substring(i,5)));
                }
            }
        }
    }
