     String startD = Request["txtStartDate"]; 
     String endD = Request["txtEndDate"];
     DateTime start = DateTime.ParseExact(startD,"MM/dd/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(endD,"MM/dd/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
