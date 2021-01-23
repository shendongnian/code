    public IList<Day> RemoveDays(IList<Day> days)
    {
        while (true)
        {
            if (days.Count <= 0 || !(days.First().IsActive || days.Last().IsActive)) return days;
            if (days.First().IsActive)
                days.RemoveAt(0);
            if (days.Count > 0 && days.Last().IsActive)
                days.RemoveAt(days.Count - 1);
        }
    }
