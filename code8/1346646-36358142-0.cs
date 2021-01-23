    var dateTime = DateTime.ParseExact(
        "2016-03-30T17:15:25.879Z",
        "yyyy-MM-dd'T'HH:mm:ss.FFF'Z'",
        CultureInfo.InvariantCulture,
        DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
    Console.WriteLine(dateTime);      // March 30 2016 17:15 (...)
    Console.WriteLine(dateTime.Kind); // Utc
