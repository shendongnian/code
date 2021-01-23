    var startDateTime = DateTime.Parse(starttime).Time;
    var endDateTime = DateTime.Parse(endtime).Time;
    if (endDateTime < startDateTime)
    {
        endDateTime += TimeSpan.FromDays(1);
    }
    TimeSpan timeSpent = endDateTime - startDateTime;
