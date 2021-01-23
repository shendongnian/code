    public ActionResult Merge(int days)
    {
        if (days > 0) // protect against malicious users
        {
            // return an error
        }
        var baseDate = new DateTime(2016, 2, 26,16,27,57);
        DateTime EndDate = baseDate.AddDays(days);
        DateTime StartDate = basedate.AddDays(days - 1)
        var data = context.MyTable.Where(c => c.Date > StartDate && c.Date <= EndDate );
        ....
    }
