    DayOfWeek startDayOfWeek;
    DayOfWeek endDayOfWeek;
    if (!Enum.TryParse(startDay, out startDayOfWeek))
    {
        // Something wrong happened and you have to handle it.
    }
    if (!Enum.TryParse(endDay, out endDayOfWeek))
    {
        // Something wrong happened and you have to handle it.
    }
    if (
           ((int)startDayOfWeek < (int)endDayOfWeek
             && myDate.DayOfWeek >= startDayOfWeek
             && myDate.DayOfWeek <= endDayOfWeek)
        || ((int)startDayOfWeek > (int)endDayOfWeek
             && (myDate.DayOfWeek >= startDayOfWeek
                 || myDate.DayOfWeek <= endDayOfWeek))
       )
    {
    }
