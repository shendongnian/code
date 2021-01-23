    DateTime reportDate;
    if (!DateTime.TryParse(result,
        System.Globalization.CultureInfo.GetCultureInfo("se-SE"),
        System.Globalization.DateTimeStyles.None, out reportDate))
    {
        ModelState.AddModelError("Date", "Felaktikt datum");
    }
