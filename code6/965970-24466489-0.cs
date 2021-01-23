    DayOfWeek[] daysOfWeek= { DayOfWeek.Moday, DayOfWeek.Thursday, DayOfWeek.Friday};
    DateTime end = Enumerable.Range(0, int.MaxValue)
                .Select(i => DateTime.Today.AddDays(i))
                .Where(d => daysOfWeek.Contains(d.DayOfWeek))
                .Take(10)
                .Last();
