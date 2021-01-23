    DateTime counter = new DateTime(2015, 1, 5); // first week of 2015 start on Monday Jan 5 2015
    int currentMonth = counter.Month;
    List<string> rows = new List<string>();
    while (counter <= DateTime.Now)
    {
        DateTime startDate = counter;
        DateTime endDate = startDate.AddDays(6);
        if (!startDate.Month.Equals(currentMonth))
        {   //When the month change it writes the name of the new month
            rows.Add("<br>" + startDate.AddMonths(-1).ToString("MMMM"));
            currentMonth++;
        }
        //I delete your '<br>' at the end to use it in the Join(), also you were missing the closing tag '</a>'
        rows.Add("<a href='/details.aspx?start=" + startDate.ToShortDateString() + "&end=" + endDate.ToShortDateString() + "' target='_blank'>" + startDate.ToLongDateString() + " - " + endDate.ToLongDateString() + "</a>");
        counter = endDate.AddDays(1);
    }
    rows.Reverse(); //Reverse the order of the array
    Response.Write(string.Join("<br>", rows.ToArray())); // Join the array in one line to just call one time the ResponseWrite
