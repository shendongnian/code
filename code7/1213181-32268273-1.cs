    DateTime reportDate;
    if (!DateTime.TryParse(result,
        System.Globalization.CultureInfo.GetCultureInfo("sv-SE"),
        System.Globalization.DateTimeStyles.None, out reportDate))
    {
        ModelState.AddModelError("Date", "Felaktikt datum");
    }
