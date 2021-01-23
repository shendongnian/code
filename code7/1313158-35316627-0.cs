    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()
        {
            var text = "Feb 5, 2016 7:45 PM";
            var zone = DateTimeZoneProviders.Tzdb["Europe/Istanbul"];
            var pattern = LocalDateTimePattern.CreateWithInvariantCulture("MMM d, YYYY h:mm tt");
            var local = pattern.Parse(text).Value;
            var zoned = local.InZoneStrictly(zone);
            var utc = zoned.WithZone(DateTimeZone.Utc);
            Console.WriteLine(utc); // 2016-02-05T17:45:00 UTC (+00)
        }
    }
