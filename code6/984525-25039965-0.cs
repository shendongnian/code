    // Initially, we have to parse the weekBeginDate string to create a DateTime object
    // and then we add six days to this DateTime object.
    DateTime dt = DateTime.Parse(WeekBeginDate).AddDays(6);
    // Then we assign the string representation of the DateTime object we have created before.
    Chart1.Titles[0].Text = dt.ToString() ;
