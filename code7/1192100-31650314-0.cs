    public List<Event> Events = new List<Event>();
    Boss tequalt = new Boss("Tequatl the Sunless", BossPriority.HardCore) { Location = "Splintered Coast", Image = "tequatl.jpg" };
    Events.AddRange(new List<Event>
    {
        new Event("07:00", tequalt),
        new Event("11:30", tequalt)
    });	
    public List<Event> GetEvents(int count)
    {
        InitializeTimers();
        var timeSpanPattern = Events.OrderBy(x => x.Time.Hours).ThenBy(x => x.Time.Hours);
        var newOrder = new List<Event>();
        var previousTimes = new List<Event>();
        foreach (var timespan in timeSpanPattern)
        {
            if (timespan.Time.CompareTo(DateTime.Now.TimeOfDay) != -1)
                newOrder.Add(timespan);
            else
                previousTimes.Add(timespan);
        }
        newOrder.AddRange(previousTimes);
        var finalList = new List<Event>();
        for (int i = 0; i < count; i++)
        {
            int extraDays = i / (newOrder.Count);
            int current = i - (extraDays * newOrder.Count);
            if (newOrder[current].Time.CompareTo(DateTime.Now.TimeOfDay) != 1)
                extraDays++;
            DateTime time = DateTime.ParseExact(newOrder[current].Time.Hours + ":" + newOrder[current].Time.Minutes + " +0000", "H:m zzz", CultureInfo.InvariantCulture).AddDays(extraDays);
            var newEvent = new Event { Boss = newOrder[current].Boss, DateAndTime = time, Time = newOrder[current].Time};
            newEvent.CalculateCountdown();
            finalList.Add(newEvent);
        }
        finalList.Sort((x,y) => x.DateAndTime.CompareTo(y.DateAndTime));
        return finalList;
    }
