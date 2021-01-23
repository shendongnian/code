    string[] lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
    string dateString = lines
        .FirstOrDefault(l => l.Trim().StartsWith("Ship date", StringComparison.InvariantCultureIgnoreCase));
    DateTime shipDate;
    if (dateString != null)
    {
        string[] formats = new[] { "MMMM dd, yyyy" };
        string datePart = dateString.Split(':').Last().Trim();
        bool validShipDate = DateTime.TryParseExact(
            datePart,
            formats,
            DateTimeFormatInfo.InvariantInfo,
            DateTimeStyles.None,
            out shipDate);
        if (validShipDate)
            Console.WriteLine(shipDate);
    }
