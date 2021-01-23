    int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek; // finds the difference between today and the monday of this week
    DateTime counter = input.AddDays(delta); // sets the counter the first day of this week.
    int currentMonth = DateTime.Now.Month; // current month as integer.
    while (counter >= new DateTime(2015, 1, 5))
    {
        if (currentMonth != counter.Month)
        {
            currentMonth = counter.Month;
            response.Write("my dividing text");
        }
        DateTime startDate = counter;
        DateTime endDate = startDate.AddDays(6);
        Response.Write("<a href=\"/details.aspx?start=" 
            + startDate.ToShortDateString() + "&end=" + endDate.ToShortDateString() 
            + "\" target=\"_blank\">" + startDate.ToLongDateString() + " - " 
            + endDate.ToLongDateString() + "<br>");
        counter = startDate.AddDays(-7);
     }
