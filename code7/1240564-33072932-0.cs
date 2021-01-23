    var startDateTime = DateTime.Parse(starttime).Time;
    var endDateTime = DateTime.Parse(endtime).Time;
    if (endDateTime < startDateTime)
    {
        endDateTime += TimeSpan.FromDays(1);
    }
    var hours = (endDateTime - startDateTime).TotalHours;
