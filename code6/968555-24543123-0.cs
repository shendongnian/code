    List<DayOfWeek> workingDays = new List<DayOfWeek>() { 
        DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Friday
    };
    
    var nonWorkingDays = Enumerable.Range(1, 31)
                                   .Select(x => new DateTime(2014, 7, x))
                                   .Where(d => !workingDays.Contains(d.DayOfWeek))
                                   .ToList();
