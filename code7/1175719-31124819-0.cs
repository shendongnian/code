    using System;
    
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        
        public static void Main (string[] args)
        {
            long[] timestamps = {1413685800L, 1413689400L, 1424568600L, 1424572200L, 1424575800L};
            
            var zone = DateTimeZoneProviders.Tzdb["America/Sao_Paulo"];
            var instantPattern = InstantPattern.CreateWithInvariantCulture("dd MMM yyyy HH:mm:ss");
            var zonedPattern = ZonedDateTimePattern.CreateWithInvariantCulture
                ("dd MMM yyyy HH:mm:ss o<g> (x)", null);
            
            foreach (long ts in timestamps) {
                var instant = Instant.FromSecondsSinceUnixEpoch(ts);
                var zonedDateTime = instant.InZone(zone);            
    
                Console.WriteLine("{0} UTC - {1}",                              
                    instantPattern.Format(instant),
                    zonedPattern.Format(zonedDateTime));
            }
        }
    }
