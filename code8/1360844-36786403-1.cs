    public DateTime? GetClosest(List<DateTime> dates, DateTime dateToCompare)
    {
        DateTime? closestDate = null;
        int min = int.MaxValue;
    
        foreach (DateTime date in dates)
        {
            if (Math.Abs(date.Ticks - dateToCompare.Ticks) < min)
            {
                min = date.Ticks - dateToCompare.Ticks;
                closestDate = date;
            }
        }
        return closestDate;
    }
