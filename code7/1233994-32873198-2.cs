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
            static void Main(string[] args)
            {
                var dict1 = new Dictionary<string, string>();
                dict1.Add(":-)", "***http://smile.jpg***");
                dict1.Add(":/", "***http://hmmm.jpg***");
                dict1.Add(":(", "***http://sad.jpg***");
                dict1.Add("):(", "***http://strange? :)***");
                string input = ":-) This is just a quick solution:- Suggestions are welcome  :/  :( :))";
                StringBuilder output = new StringBuilder();
                for (int c = 0; c < input.Length; c++)
                {
                    bool found = false;
                    foreach (KeyValuePair<string, string> item in dict1.OrderByDescending(x => x.Key.Length))
                    {
                        if (input.Substring(c).StartsWith(item.Key))
                        {
                            //match found
                            found = true;
                            output.Append(item.Value);
                            break;
                        }
                    }
                    if (!found)
                        output.Append(new string(new[] {input[c]}));
                }
                Console.WriteLine("input");
                Console.WriteLine(input);
                Console.WriteLine();
                Console.WriteLine("output");
            
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
