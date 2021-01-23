    DateTime timeIn = new DateTime(2015, 09, 29, 10, 11, 3); // 29-09-2015 at 10:11:03
    DateTime timeOut = new DateTime(2015, 10, 1, 2, 19, 18); // 01-10-2015 at 02:19:38
    // Get days
    TimeSpan passLength = new TimeSpan(1, 0, 0, 0); // one day per iterate
    while (timeIn + passLength < timeOut)
    {
        timeIn = timeIn.Add(passLength);
        nightTime = nightTime.Add(new TimeSpan(0, 7, 0, 0)); // 7 hours of a day passed is considered night time
    }
    // Get rest of the time
    passLength = new TimeSpan(0, 0, 0, 1); // one second per iterate
    while (timeIn < timeOut) // do it until timeIn reaches timeOut
    {
         timeIn = timeIn.Add(passLength); // add 1 second to timeIn
         if (timeIn.Hour < 6 || timeIn.Hour == 23) // if we are in range of night time
         {
             nightTime = nightTime.Add(passLength); // add 1 second to night time
         }
    }
    Console.WriteLine(nightTime);
