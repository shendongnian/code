    public static TimeSpan GetTimeDifference(string startTimeOfDay, string endTimeOfDay)
    {
        DateTime startDateTime = DateTime.ParseExact(startTimeOfDay, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault);
        DateTime endDateTime = DateTime.ParseExact(endTimeOfDay, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault);
        if (endDateTime >= startDateTime)
        {
            // values do not cross over midnight
            return endDateTime - startDateTime;
        }
        else
        {
            // values cross over midnight
            return endDateTime - startDateTime + TimeSpan.FromHours(24);
        }
    }
