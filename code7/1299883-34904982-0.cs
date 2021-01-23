    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                "139862,2 - 455452,6 - 13:24:53\n" +
                "139860,8 - 455452,2 - 13:25:13\n" +
                "139859,3 - 455452,2 - 13:25:33\n";
                string inputLine = "";
                StringReader reader = new StringReader(input);
                while((inputLine = reader.ReadLine()) != null)
                {
                    string[] inputArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine("X:{0} {1} Y:{2} {3} D:{4}", inputArray[0], inputArray[1], inputArray[2], inputArray[3], inputArray[4]);
                }
                Console.ReadLine();
            }
        }
    }
