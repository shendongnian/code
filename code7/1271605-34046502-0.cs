    public JsonResult GetCalendarByParam(int year, string month, int date, string type, string operation)
    {
        DateWeekModels returnDate = new DateWeekModels();
        returnDate.Week = new List<Day>();
        for (int i=0; i<7; i++) {
            returnDate.Week.Add(new Day());
        }
        var monthReceive = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
        var dt = new DateTime(year, monthReceive, date);
        switch (type)
        {
            case "Month":
                if (operation == "+")
                {
                    dt = dt.AddMonths(1);
                }
                else
                {
                    dt = dt.AddMonths(-1);
                    if (DateTime.Compare(dt, DateTime.Now) < 0)
                    {
                        dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    }
                }
                break;
            case "Week":
                if (operation == "+")
                {
                    dt = dt.AddDays(7);
                }
                else
                {
                    dt = dt.AddDays(-7);
                    if (DateTime.Compare(dt, DateTime.Now) < 0)
                    {
                        dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    }
                }
                break;
        }
        dt.ToString("ddd", new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name));
        returnDate.Year = dt.Year;
        returnDate.Month = dt.ToString("MMMM", new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name));
        foreach (Day thisDay in returnDate.Week)  {
            thisDay.dayName = dt.ToString("ddd", new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name));
            thisDay.dayNumber = dt.Day;
            dt = dt.AddDays(1);
        }
        return Json(returnDate, JsonRequestBehavior.AllowGet);
    }
