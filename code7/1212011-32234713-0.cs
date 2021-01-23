    private static string PrettyPrint(TimeSpan timeSpan)
    {
        var parts = new List<string>();
        int totalHours = (int)timeSpan.TotalHours;
        int workDays = totalHours / 8;
        int remainingHours = (int)timeSpan.TotalHours - 8 * workDays;
        if (workDays == 1) parts.Add("1 day");
        if (workDays > 1) parts.Add(workDays + " days");
            
        if (remainingHours == 1) parts.Add("1 hour");
        if (remainingHours > 1) parts.Add(timeSpan.Hours + " hours");
            
        if (timeSpan.Minutes == 1) parts.Add("1 minute");
        if (timeSpan.Minutes > 1) parts.Add(timeSpan.Minutes + " minutes");
        return string.Join(", ", parts);
    }
