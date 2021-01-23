    public DateTime AddBusinessDays(DateTime dateTime, int n, IEnumerable<DayOfWeek> businessDays)
    {
        var tmpDate = dateTime;
        while (n > 0)
        {
            tmpDate = tmpDate.AddDays(1);
            if (businessDays.Any(b => b == tmpDate.DayOfWeek))
                n--;
        }
        return tmpDate;
    }
