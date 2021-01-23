    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace testpro1
    {
        class Program
        {
           public string[] poarr = null;
            
            static void Main(string[] args)
            {
                string strRegex = @"([0-9]*\.[0-9]+|[0-9]+)";
                string strTargetString = @"(29.67850809103362, 79.74288940429688),(29.367814384775375, 79.29519653320312),(29.561512529746768, 79.20455932617188),(29.69759650228319, 79.45449829101562)";
                //matches is the array
                Match[] matches = Regex.Matches(strTargetString, strRegex)
                             .Cast<Match>()
                             .ToArray();
                Console.WriteLine("The Array Values are:\n");
                foreach (var item in matches)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }
    }
