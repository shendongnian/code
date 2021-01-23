    var dateformats = new[] { "dd/mm/yyyy", "dd.mm.yyyy", "dd,mm,yyyy" };
    
    DateTime.ParseExact("23/04/2015", dateformats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
    DateTime.ParseExact("23.04.2015", dateformats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
    DateTime.ParseExact("23,04,2015", dateformats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
