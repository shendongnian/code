    using System;
    using System.Globalization;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            var german = CultureInfo.GetCultureInfo("de-DE");
            var english = CultureInfo.GetCultureInfo("en-GB");
            var text = "1.5";
            
            Thread.CurrentThread.CurrentCulture = german;
            Console.WriteLine(double.Parse(text) == 1.5); // False
    
            Thread.CurrentThread.CurrentCulture = english;
            Console.WriteLine(double.Parse(text) == 1.5); // True
        }
    }
