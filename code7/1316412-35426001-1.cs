    using System;
    using System.Globalization;
    using System.Threading;
    using static System.FormattableString;
    
    class Test
    {
        static void Main()
        {
            var uk = CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture = uk;
            var germany = CultureInfo.CreateSpecificCulture("de-DE");
            string now = $"Default: it is now {DateTime.UtcNow}";
            Console.WriteLine(now); // UK format
            IFormattable x = $"Specific: It is now {DateTime.UtcNow}";
            Console.WriteLine(x.ToString("ignored", germany));
            FormattableString y = $"FormattableString: It is now {DateTime.UtcNow}";
            Console.WriteLine(FormattableString.Invariant(y));
            // Via using static
            Console.WriteLine(Invariant($"It is now {DateTime.UtcNow}")); 
        }
    }
