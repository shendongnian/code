    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string strDate = "December 13, 2015 09:55 PM";
                DateTime date = DateTime.ParseExact(strDate, "MMMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture);
            }
        }
    }
    ​
