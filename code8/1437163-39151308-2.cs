    private static void Search(string date)
    {
        DateTime parsedDate;
        if (DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        {
            var dateString = parsedDate.ToString("yyyy-MM-dd");
            var dateStart = dateString + "T00:00:00Z";
            var dateEnd = dateString + "T23:59:59Z";
        }
    }
