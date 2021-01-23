    DateTime dtime1 = DateTime.Now;       
    int iTotalDays = DateTime.DaysInMonth(dtime1.Year, dtime1.Month);
    for (int i = 1; i <= iTotalDays; i++)
    {
        var d = new DateTime(dtime1.Year, dtime1.Month, i);
        if (d.DayOfWeek == DayOfWeek.Monday)          
            Response.Write(d.ToString("dd/MM/yyyy") + "</br>");
    }
