    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            var french = CultureInfo.GetCultureInfo("fr-FR");
            decimal value = decimal.Parse("0,1099", french);
            Console.WriteLine(value.ToString(CultureInfo.InvariantCulture)); // 0.1099
        }
    }
