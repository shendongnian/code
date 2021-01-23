    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main(string[] args)
        {
            string text = "2015-06-10 20:52:13";        
            string format = "yyyy-MM-dd HH:mm:ss";
            var dateTime = DateTime.ParseExact(
                text,
                format, 
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            Console.WriteLine(dateTime);  // 10/06/2015 20:52:13 on my box
            Console.WriteLine(dateTime.Kind); // Utc
        }
    }
