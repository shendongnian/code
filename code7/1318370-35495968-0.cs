    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    namespace julian2gregorian
    {
        class Program
        {
            private static JulianCalendar jcal;
            static void Main(string[] args)
            {
                jcal = new JulianCalendar();
                string jDateString = "1104-08-16";
                char[] delimiterChars = { '-' };
                string[] dateParts = jDateString.Split(delimiterChars);
                int jyear, jmonth, jday;
                bool success = int.TryParse(dateParts[0], out jyear);
                success = int.TryParse(dateParts[1], out jmonth);
                success = int.TryParse(dateParts[2], out jday);
                DateTime myDate = new DateTime(jyear, jmonth, jday, 0, 0, 0, 0, jcal);
                Console.WriteLine("Date converted to Gregorian: {0}", myDate);
                Console.ReadLine();
            }
        }
    }
