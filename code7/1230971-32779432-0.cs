    var date = new DateTime(2015, 10, 25, 1, 20, 00).ToUniversalTime();
    Console.WriteLine($"UTC: {date}\tDST: {date.ToLocalTime().IsDaylightSavingTime()}\t{date.ToLocalTime()}");
    date = date.AddMinutes(50);
    Console.WriteLine($"UTC: {date}\tDST: {date.ToLocalTime().IsDaylightSavingTime()}\t{date.ToLocalTime()}");
    date = date.AddMinutes(50);
    Console.WriteLine($"UTC: {date}\tDST: {date.ToLocalTime().IsDaylightSavingTime()}\t{date.ToLocalTime()}");
    date = date.AddMinutes(50);
    Console.WriteLine($"UTC: {date}\tDST: {date.ToLocalTime().IsDaylightSavingTime()}\t{date.ToLocalTime()}");
