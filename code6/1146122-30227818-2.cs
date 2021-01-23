    public static int GetMinutesDifference(string startTimeOfDay, string endTimeOfDay)
    {
        DateTime startDateTime = DateTime.ParseExact(startTimeOfDay, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault);
        DateTime endDateTime = DateTime.ParseExact(endTimeOfDay, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault);
        return (((int)(endDateTime - startDateTime).TotalMinutes + 1440) % 1440);
    }
