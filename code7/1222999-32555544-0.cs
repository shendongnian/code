    var CountryStateHolidayLookup = holidays.GroupBy(h => h.Country)
        .ToDictionary(
            g => g.Key,
            g => g.ToLookup(
                h => h.State,
                h => new Holiday(h.HolidayDate.Date, h.IsWeekend)
            )
        );
