    public DateTime? DTNullable(string DateTimestring, string CurrDateTimeFormat)
    {
        if (string.IsNullOrEmpty(DateTimestring)) return null;
        else
        {
            DateTime datetimeNotNull;
            DateTime.TryParseExact(DateTimestring, CurrDateTimeFormat, null, System.Globalization.DateTimeStyles.None, out datetimeNotNull);
            return datetimeNotNull;
        }
    }
