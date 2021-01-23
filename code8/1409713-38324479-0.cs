     public static decimal GetNightDifferentialValue(this DailyTime dtr, Employee201 employee, PayrollSettings settings, IEnumerable<Holidays> holidays)
        {
            //know if the time out is greater than 10pm of the dtr
            //07-26-2016 14:00 - 07-27-2016 03:00
            //if time out i
            var days = Enumerable.Range(0, (int)(dtr.TimeOut - dtr.TimeIn).TotalHours + 1)
                .Select(i => dtr.TimeIn.AddHours(i))
                .Where(date => (date.Hour == 5)).Count();
            return days;
    
        }
