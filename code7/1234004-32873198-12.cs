    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
   
    namespace ConsoleApplication6
    {
        class Program
        {   
            public static string ReplaceMethod(string input, //... as above
                                                 Dictionary<string,string> dict1) 
            static void Main(string[] args)
            {
                var dict1 = new Dictionary<string, string>();
                dict1.Add(":-)", "***http://smile.jpg***");
                dict1.Add(":/", "***http://hmmm.jpg***");
                dict1.Add(":(", "***http://sad.jpg***");
                dict1.Add("):(", "***http://strange? :)***");
                string input = ":-) This is just a quick solution:-" +
                               "Suggestions are welcome  :/  :( :)):(";
                string output = ReplaceMethod(input, dict1);
                Console.WriteLine("input");
                Console.WriteLine(input);
                Console.WriteLine();
                Console.WriteLine("output");            
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
