    private static void Search(string date)
    {
        DateTime parsedDate;
        if (DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out parsedDate))
        {
            var dateStart = parsedDate.ToString("s") + "Z"; // z suffix is not included with s format
            var startEnd = dateStart.Substring(0,10) + "T23:59:59Z";
        }
    }
