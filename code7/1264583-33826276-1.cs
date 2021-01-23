    /// <summary>
    /// Calculates the next annual day of this instance of System.DateTime relative to today.
    /// <para>Calculates correctly Feb. 28th as an annual day in common years for event dates of Feb. 29th.</para>
    /// </summary>
    /// <param name="eventDate">The date of the event.</param>
    /// <returns>The date of the upcoming annual day.</returns>
    public static DateTime NextAnnualDay(this DateTime eventDate)
    {
        return NextAnnualDay(eventDate, DateTime.Today);
    }
    /// <summary>
    /// Calculates the next annual day of this instance of System.DateTime relative to a future date.
    /// <para>Calculates correctly Feb. 28th as an annual day in common years for event dates of Feb. 29th.</para>
    /// <para>If futureDate is earlier than this instance, the value of this instance is returned.</para>
    /// </summary>
    /// <param name="eventDate">The date of the event.</param>
    /// <param name="futureDate">The date from which to find the next annual day of this instance.</param>
    /// <returns>The date of the upcoming annual day.</returns>
    public static DateTime NextAnnualDay(this DateTime eventDate, DateTime futureDate)
    {
        DateTime nextAnnualDay = eventDate;
        int years = futureDate.Year - eventDate.Year;
        if (years >= 0)
        {
            nextAnnualDay = eventDate.AddYears(years);
            if (nextAnnualDay.Subtract(futureDate).Days <= 0)
            {
                nextAnnualDay= eventDate.AddYears(years + 1);
            }
        }
        return nextAnnualDay;
    }
