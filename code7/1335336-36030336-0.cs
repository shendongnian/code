    DateTime selectedDate = new DateTime( Convert.ToInt32(YearNumber)
                                        , Convert.ToInt32(MonthNumber)
                                        , Convert.ToInt32(DayNumber)
                                        );
    if (selectedDate > DateTime.Now)
    {
        // error
    }
