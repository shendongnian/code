        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Globalization;
        namespace DateTimeConvert
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var text1 = "Jul 24, 2015 9:08:19 PM PDT";
                    var text2 = "Jul 26, 2015 2:13:54 PM PDT";
                
                    string format = "MMM d, yyyy h:m:s tt PDT";
                    var date1 = DateTime.ParseExact(text1, format, CultureInfo.InvariantCulture);
                    Console.WriteLine(date1);
                    var date2 = DateTime.ParseExact(text2, format, CultureInfo.InvariantCulture);
                    Console.WriteLine(date2);
                    Console.ReadLine();
                }
            }
        }
