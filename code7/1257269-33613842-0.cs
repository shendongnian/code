    List<DateTime> dates = new List<DateTime>() {
        new DateTime(2014, 1, 1),
        new DateTime(2014, 1, 2),
        new DateTime(2014, 1, 8),
        new DateTime(2014, 1, 10),
        new DateTime(2014, 1, 11),
        new DateTime(2014, 1, 12)
    };
    List<List<DateTime>> limits = new List<List<DateTime>>();
    foreach (DateTime date in dates)
    {
        if (!limits.Any() || limits.Last().Last().AddDays(1) < date)
        {
            // add new limit group with the current date as startdate
            limits.Add(new List<DateTime>() { date });
        }
        else
        {
            if (limits.Last().Count == 1)
            {
                // add the current date as new end date for the last limit group
                limits.Last().Add(date);
            }
            else
            {
                // replace end date from last limit group with the current date
                limits.Last()[1] = date;
            }
        }
    }
