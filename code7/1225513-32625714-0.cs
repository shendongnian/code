    public DateTime GetBirthDate(string ssn)
    {
        var strippedOfSerial =
            ssn.Substring(0, ssn.Length - 4).TrimEnd('-');
        return DateTime.ParseExact(
            strippedOfSerial,
            new[] { "yyMMdd", "yyyyMMdd" },
            new CultureInfo("se-SE"),
            DateTimeStyles.None);
    }
