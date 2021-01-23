    using System;
    using System.Linq;
    using NodaTime;
    ...
    // Get some time zones.  You can use Tzdb or Bcl zones here.
    DateTimeZone sourceZone = DateTimeZoneProviders.Bcl["GMT Standard Time"]; // London
    DateTimeZone destinationZone = DateTimeZoneProviders.Bcl["Mountain Standard Time"]; // Denver
    // Determine the period of time we're interested in evaluating.
    // I'm taking today in the source time zone, up to 10 years in the future.
    Instant now = SystemClock.Instance.Now;
    Instant start = sourceZone.AtStartOfDay(now.InZone(sourceZone).Date).ToInstant();
    Instant end = start.InZone(sourceZone).LocalDateTime.PlusYears(10).InZoneLeniently(sourceZone).ToInstant();
    // Get the intervals for our each of the zones over these periods
    var sourceIntervals = sourceZone.GetZoneIntervals(start, end);
    var destinationIntervals = destinationZone.GetZoneIntervals(start, end);
    // Find all of the instants we care about, including the start and end points,
    // and all transitions from either zone in between
    var instants = sourceIntervals.Union(destinationIntervals)
        .SelectMany(x => new[] {x.Start, x.End})
        .Union(new[] {start, end})
        .OrderBy(x => x).Distinct()
        .Where(x => x >= start && x < end)
        .ToArray();
    // Loop through the instants
    for (int i = 0; i < instants.Length -1; i++)
    {
        // Get this instant and the next one
        Instant instant1 = instants[i];
        Instant instant2 = instants[i + 1];
        // convert each instant to the source zone
        ZonedDateTime zdt1 = instant1.InZone(sourceZone);
        ZonedDateTime zdt2 = instant2.InZone(sourceZone);
        // Get the offsets for instant1 in each zone 
        Offset sourceOffset = zdt1.Offset;
        Offset destOffset = destinationZone.GetUtcOffset(instant1);
        // Calc the difference between the offsets
        int deltaSeconds = (destOffset.Milliseconds - sourceOffset.Milliseconds)/1000;
        // Convert to the same types you had in your example (optional)
        DateTime dt1 = zdt1.ToDateTimeUnspecified();
        DateTime dt2 = zdt2.ToDateTimeUnspecified();
        // emit output
        Console.WriteLine("{0}\t{1}\t{2}", dt1, dt2, deltaSeconds);
    }
