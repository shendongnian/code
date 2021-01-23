    var monthsInTimeFrame = new List<DateTime>();
    for(int i = timeFrame; i>=0 ; i--)
    { 
        monthsInTimeFrame.Add(DateTime.Now.AddMonths(-i));
    }
