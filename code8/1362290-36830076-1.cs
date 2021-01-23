    OpenHours oh = GetOpenHours();
    DateTime now = DateTime.Now;
    bool todayOpen = GetOpenDay(oh, now.DayOfWeek);
    TimeSpan begin = GetOpenStart(oh, now.DayOfWeek);    
    TimeSpan end = GetOpenEnd(oh, now.DayOfWeek);
    //Calculate duration
    TimeSpan duration = end < begin? (TimeSpan.FromHours(24) - begin) + end : end - begin;
    //calculate opening time using begin
    DateTime openingTime = DateTime.Today.Add(begin);
    //calculate closing time based on opening time and duration
    DateTime closingTime = openTime.Add(duration);
    return todayOpen && (openingTime <= now && now < closingTime);
        
