    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication53
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime x = DateTime.ParseExact("3 june 2015 9:12:14 PM GMT", "d MMMM yyyy h:mm:ss tt Z", CultureInfo.InvariantCulture);
                string y = x.ToString("d MMMM yyyy h:mm:ss tt K", CultureInfo.CreateSpecificCulture("nl-NL"));
                string dutchTimeString = "3 juni 2015 9:12:14 uur CEST";
                DateTime date = DateTime.ParseExact(dutchTimeString, "d MMMM yyyy h:mm:ss tt Z", CultureInfo.CreateSpecificCulture("nl-BE"));
     
            }
        }
    }
