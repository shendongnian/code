    List<string> holidayDifference = new List<string>();
    List<string> remoteHolidays = new List<string> { "1", "2", "3" };
    List<string> localHolidays = new List<string> { "1", "3" };
    holidayDifference = remoteHolidays
        .Except(localHolidays)
        .ToList();
    holidayDifference.ForEach(Console.WriteLine);
