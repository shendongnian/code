    String startD = Request["txtStartDate"]; 
    String endD = Request["txtEndDate"];
    DateTime start = DateTime.ParseExact(startD, "MM/dd/yyyy",
                      new CultureInfo("en-US"),DateTimeStyles.None);
    DateTime end = DateTime.ParseExact(endD, "MM/dd/yyyy",
                      new CultureInfo("en-US"),DateTimeStyles.None);
