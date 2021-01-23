    // _user.StartTime
    TimeSpan startTime = TimeSpan.Parse("23:59:54");        
    
    // DateTime.Now
    DateTime now = new DateTime(2014, 04, 11, 00, 05, 00);
    
    // Get the time portion of DateTime.Now
    TimeSpan endTime = now - now.Date;
    
    
    TimeSpan timeSpent = TimeSpan.Zero;
    
    if (endTime > startTime)
        timeSpent = endTime - startTime;
    else
        timeSpent = endTime - startTime + TimeSpan.FromHours(24);
    
    Console.WriteLine(timeSpent);
