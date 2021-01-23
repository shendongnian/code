    //Declare the weekly object:
    myWeeklyObject thisWeek = new myWeeklyObject();
    //Populate variables of thisWeek here:
    thisWeek.ObjectID = thisWeek.WeekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    //The line above gets the current weekNo for the year.
