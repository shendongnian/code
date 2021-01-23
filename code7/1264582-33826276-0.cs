    public static DateTime NextAnnualDay(this DateTime currentDate)
    {
        DateTime today = DateTime.Today;
        DateTime nextAnnualDay = currentDate.AddYears(today.Year - currentDate.Year);
        if (nextAnnualDay.Subtract(today).Days <= 0)
        {
            return nextAnnualDay.AddYears(1);
        }
        else
        {
            return nextAnnualDay;
        }
    }
