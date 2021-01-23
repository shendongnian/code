        var startDate = new DateTime(2016, 06, 17);
        var endDate = new DateTime(2016, 06, 30);
        DayOfWeek[] daysOfWeek = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Friday };
        
        List<DateTime> dates = new List<DateTime>();
        if (endDate >= startDate)
        {
            var tmp = startDate;
            tmp = tmp.AddDays(1); //I notice you didn't add 06/17/2016 that is friday, if you want to add it, just remove this line
            do
            {
                if (daysOfWeek.Contains(tmp.DayOfWeek))
                    dates.Add(tmp);
                tmp = tmp.AddDays(1);
            }
            while (tmp <= endDate); //If you don't want to consider endDate just change this line into while (tmp < endDate); 
        }
