    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    namespace ConsoleApplication6
    {
        class Program
        {
            public static string ReplaceFunction(string input, Dictionary<string,string> dict1 )
            {
                StringBuilder output = new StringBuilder();
                
                for (int c = 0, itemLength = 1; c < input.Length; c+=itemLength)
                {
                    //descend by order
                    bool found = false;
                    foreach (KeyValuePair<string, string> item in dict1.OrderByDescending(x => x.Key.Length))
                    {
                        if (input.Substring(c).StartsWith(item.Key))
                        {
                            //match found
                            found = true;
                            c+=item.Key.Length;
                            output.Append(item.Value);
                            break;
                        }
                    }
                    if (!found)
                        output.Append(input[c]);
                }
                return output.ToString();
            }
            static void Main(string[] args)
            {
                var dict1 = new Dictionary<string, string>();
                dict1.Add(":-)", "***http://smile.jpg***");
                dict1.Add(":/", "***http://hmmm.jpg***");
                dict1.Add(":(", "***http://sad.jpg***");
                dict1.Add("):(", "***http://strange? :)***");
                string input = ":-) This is just a quick solution:- Suggestions are welcome  :/  :( :)):(";
                string output = ReplaceFunction(input, dict1);
                Console.WriteLine("input");
                Console.WriteLine(input);
                Console.WriteLine();
                Console.WriteLine("output");            
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
