    public DateTime GetNextAnniversaryDate(DateTime anniversary)
    {
        var today = DateTime.Today;
        var year = anniversary.Month < today.Month || 
                  (anniversary.Month == today.Month && anniversary.Day < today.Day)
            ? today.Year + 1 : today.Year;
        return anniversary.Month == 2 && anniversary.Day == 29 &&
               !DateTime.IsLeapYear(year)
            ? new DateTime(year, 2, 28)
            : new DateTime(year, anniversary.Month, anniversary.Day);
    }
    public int GetDaysUntilNextAnniversary(DateTime anniversary)
    {
        var nextDate = GetNextAnniversaryDate(anniversary);
        return (int)(nextDate - DateTime.Today).TotalDays;
    }
