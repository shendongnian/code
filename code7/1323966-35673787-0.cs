    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    
    namespace testing
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string bDay = Console.ReadLine();
                DateTime convert = DateTime.ParseExact(bDay, "dd-MM-yyyy", CultureInfo.InstalledUICulture);
                convert = convert.AddDays(999);
                string formatted = convert.ToString("dd-MM-yyyy");
    
    
                Console.WriteLine(formatted);
                Console.ReadLine();
            }
        }
    }
