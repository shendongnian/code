    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<String> similarStrings = new List<String> {"abc", "ab-c", "hfcx-h", "hfcxh", "hf  --  cx --- h"};
                foreach (String tempString in similarStrings)
                {
                    String foreachvar = tempString;
                    Console.Write("Similiar Strings to " + tempString + " >>> ");
                    foreachvar = System.Text.RegularExpressions.Regex.Replace(foreachvar, @"\s|-", @".*");
                    List<String> filtered = similarStrings.Where<String>(item => !item.Equals(tempString) && System.Text.RegularExpressions.Regex.IsMatch(item, foreachvar)).ToList<String>();
                    foreach (String filteredTemp in filtered)
                    {
                        Console.Write(filteredTemp + " ");
                    }
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
        }
    }
