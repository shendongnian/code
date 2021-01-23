    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication64
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "0,1,2,3,4,5,6,7,8,9\n" +
                    "10,11,12,13,14,15,16,17,18,19\n" +
                    "20,21,22,23,24,25,26,27,28,29\n" +
                    "30,31,32,33,34,35,36,37,38,39\n" +
                    "40,41,42,43,44,45,46,47,48,49\n";
                List<List<int>> output = new List<List<int>>();
                StringReader reader = new StringReader(input);
                string inputline = "";
                while ((inputline = reader.ReadLine()) != null)
                {
                    List<int> numbers = inputline.Split(new char[] { ',' }).Select(x => int.Parse(x)).ToList();
                    output.Add(numbers);
                }
            }
        }
    }
