    DateTime tempStart = StartDate;
    var list = new List<Splitdate>();
    for (DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
    {
        if (day.ModifiedDate.Value.DayOfWeek == DayOfWeek.Saturday)
        {
            var temp = new Splitdate();
            temp.Fromdate = tempStart;
            temp.Todate = date.AddDays(-1);
            list.Add(temp);
            tempStart.AddDays(2);
        }
    }
    if (tempStart <= EndDate)
    {
        var temp = new Splitdate();
        temp.Fromdate = tempStart;
        temp.Todate = EndDate;
        list.Add(temp);
    }
