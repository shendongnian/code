    string startDateInText = "01/01/2014";
    string endDateInText = "31/12/2014";
    System.DateTime startDate = DateTime.ParseExact(startDateInText, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
    System.DateTime endDate = DateTime.ParseExact(endDateInText , "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
    System.TimeSpan diff = endDate.Subtract(startDate);
    //diff.Days will provide difference in Days`
