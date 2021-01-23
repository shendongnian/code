    using System;
    using System.Globalization;
    using NodaTime.Text;
    using NodaTime;
    
    class Program
    {
        static void Main()
        {
            var culture = (CultureInfo) CultureInfo.InvariantCulture.Clone();
            culture.DateTimeFormat.AMDesignator = "a.m.";
            culture.DateTimeFormat.PMDesignator = "p.m.";
            string text = "1:15 P.M.";
            var pattern = LocalTimePattern.Create("h:mm tt", culture);
            var value = pattern.Parse(text).Value;
            Console.WriteLine(value);
        }   
    }
