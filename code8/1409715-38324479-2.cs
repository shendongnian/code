     public static decimal GetNightDifferentialValue(this DailyTime dtr, Employee201 employee, PayrollSettings settings, IEnumerable<Holidays> holidays)
        {
            //know if the time out is greater than 10pm of the dtr
            //07-26-2016 14:00 - 07-27-2016 03:00
            //if time out i
            DateTime dayIn10pm = new DateTime(dtr.TimeIn.Year, dtr.TimeIn.Month, dtr.TimeIn.Day, 22, 0, 0);
            DateTime dayAfter04am = dayIn10pm.Add(new TimeSpan(6,0,0));
            var hours = Enumerable.Range(0, (int)(dtr.TimeOut - dtr.TimeIn).TotalHours + 1)
                .Select(i => dtr.TimeIn.AddHours(i))
                .Where(date => (date > dayIn10pm && date <= dayAfter04am)).Count();
            return hours;
    
        }
