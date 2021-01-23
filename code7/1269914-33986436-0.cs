    String pattern = "dd-MMM-yyyy";
    DateTime dt;
    if (DateTime.TryParseExact(values[0], pattern, CultureInfo.InvariantCulture, 
                               DateTimeStyles.None,
                               out dt)) {
        // dt is the parsed value
        String sdt = dt.ToString("yyyyMMdd"); // <<--this is the string you want
    } else {
        // Invalid string, handle it as you see fit
    }
