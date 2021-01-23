    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DateParse
    {
        class Program
        {
            static void Main(string[] args)
            {
                var time = "17/8/2015 11:43:48 AM";
    
                Console.WriteLine("Before: " + time);
    
                DateTime newDT = DateTime.ParseExact(time, "dd/M/yyyy hh:mm:ss tt", null);
    
                Console.WriteLine("After: "+newDT.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
        }
    }
