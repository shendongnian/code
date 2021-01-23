    private long MaxOfThreeDate(DateTime? date1, DateTime? date2, DateTime? date3)
    {
        long max1 = Math.Max(date1.GetValueOrDefault().Ticks, date2.GetValueOrDefault().Ticks);
    
        return Math.Max(max1, date3.GetValueOrDefault().Ticks);
    }
