    DateTime date;
    DateTime.TryParseExact(
        gitDateString,
        "ddd MMM d HH:mm:ss yyyy K",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None,
        out date
    );
