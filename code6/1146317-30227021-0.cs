    public static bool IsDifferenceLessThan(Period p, LocalDate d1, LocalDate d2)
    {
        if (p.HasTimeComponent)
            throw new ArgumentException("Can only compare dates.", "p");
    
        if (p.Years != 0)
        {
            if (p.Months != 0 || p.Weeks != 0 || p.Days != 0)
                throw new ArgumentException("Can only compare one component of a period.", "p");
    
            var years = Period.Between(d1, d2, PeriodUnits.Years).Years;
            return years < p.Years;
        }
    
        if (p.Months != 0)
        {
            if (p.Weeks != 0 || p.Days != 0)
                throw new ArgumentException("Can only compare one component of a period.", "p");
    
            var months = Period.Between(d1, d2, PeriodUnits.Months).Months;
            return months < p.Months;
        }
    
        if (p.Weeks != 0)
        {
            if (p.Days != 0)
                throw new ArgumentException("Can only compare one component of a period.", "p");
    
            var weeks = Period.Between(d1, d2, PeriodUnits.Weeks).Weeks;
            return weeks < p.Weeks;
        }
    
        var days = Period.Between(d1, d2, PeriodUnits.Days).Days;
        return days < p.Days;
    }
