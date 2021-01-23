    using System;
    using System.Globalization;
    
    public class Test
    {
        static void Main()
        {
            var culture = new CultureInfo("fa-ir");
            var now = DateTime.Now;
            Console.WriteLine(now.ToString(culture));
        }
    }
