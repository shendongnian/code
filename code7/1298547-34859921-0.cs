    using System;
    using System.Globalization;
    using static System.FormattableString;
    
    class Test
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            double d = 0.5;
            string local = $"{d}";
            string invariant = Invariant($"{d}");
            Console.WriteLine(local);     // 0,5
            Console.WriteLine(invariant); // 0.5
        }    
    }
