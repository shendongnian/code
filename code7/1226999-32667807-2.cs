    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    
    namespace _32666940
    {
        
        class Program
        {
            public static String str = "function customFunction(param){ " +
                "if(param.isOK == yes){}" +
                "if(param.hasMenu == no){}" +
                "if(param.cancelText == \"cancel\"){}" +    // I had to add \ before "
                "if(param[  'isOK'  ] == yes){}" +
                "if(param[\"isOK\"] == yes){}" +
                "}";
            static void Main()
            {
                //@"param\.[a-zA-Z_]+[a-zA-Z0-9_]*"
                Regex regex = new Regex(@"param\.[a-zA-Z_]+[a-zA-Z0-9_]*");
                Match match = regex.Match(str);
                while (match.Success)
                {
                    Console.WriteLine(match.Value);
                    match = match.NextMatch();
                }
    
                regex = new Regex(@"\bparam\[\s*(['""])(.+?)\1\s*]");
                match = regex.Match(str);
                while (match.Success)
                {
                    Console.WriteLine(match.Value);
                    match = match.NextMatch();
                }
    
                Console.ReadKey();
    
            }
        }
    }
