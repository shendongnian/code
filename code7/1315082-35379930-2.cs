    // determine the date of next given weekday
    DateTime date = GetNextWeekday(DateTime.Today, DayOfWeek.Tuesday); 
    // create a list and add the start date (if you want)
    List<DateTime> fortnights = new List<DateTime>() { date };
    // add as many "fortnights" as you like (e.g. 5)
    for (int i = 0; i < 5; i++) 
    {
        date = date.Add(TimeSpan.FromDays(14));
        fortnights.Add(date);
    }
    // use your list (here: just for printing the list in a console app)
    foreach (DateTime d in fortnights) 
    {
        Console.WriteLine(d.ToLongDateString());
    }
