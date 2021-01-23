    using System;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "20160301T162327.259 GMT";
                string pattern = "yyyyMMddTHHmmss.fff GMT";
                DateTime dateTime;
                if (DateTime.TryParseExact(text, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    // DataTime is parsed
                }
                else
                {
                    // Invalid string
                }
            }
        }
    }
