    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Program
    {
        private static readonly ZonedDateTimePattern ApplePattern =
            ZonedDateTimePattern.CreateWithInvariantCulture(
                "yyyy-MM-dd HH:mm:ss z", DateTimeZoneProviders.Tzdb);
        
        static void Main(string[] args)
        {
            ParseApple("2016-08-10 19:47:16 America/Los_Angeles");
            ParseApple("2016-08-11 02:42:16 Etc/GMT");
        }
        
        static void ParseApple(string text)
        {
            Console.WriteLine($"Parsing {text}");
            ParseResult<ZonedDateTime> result = ApplePattern.Parse(text);
            if (!result.Success)
            {
                Console.WriteLine($"Parse failed! {result.Exception.Message}");
                return;
            }
            ZonedDateTime zonedValue = result.Value;
            Console.WriteLine($"ZonedDateTime: {zonedValue}");
            // OffsetDateTime is a Noda Time type...
            OffsetDateTime offsetValue = zonedValue.ToOffsetDateTime();
            Console.WriteLine($"OffsetDateTime: {offsetValue}");
            // DateTimeOffset is the BCL type...
            DateTimeOffset dto = offsetValue.ToDateTimeOffset();
            Console.WriteLine($"DateTimeOffset: {dto}");
            Console.WriteLine();
        }
    }
