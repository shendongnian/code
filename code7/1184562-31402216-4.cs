    var startDate = new DateTime(2015, 7, 1);
    var endDate = new DateTime(2015, 9, 1);
    var workDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
        .Select(i => startDate.AddDays(i))
        .Where(date => (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday))
        .Select(i => i);
    
    
    var display = workDates
        .GroupAdjacentBy((x, y) => x.AddDays(1) == y)
        .Select(g => string.Format("Start: {0:dd/MMM/yyyy} End: {1:dd/MMM/yyyy}", g.First(), g.Last()));
