            double offset = 5.00;
            TimeSpan utcTime = new TimeSpan(1,0,0); //setting manually to your representation of 1 am.
            DateTime dtTempTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, utcTime.Hours, utcTime.Minutes, utcTime.Seconds);
            dtTempTime = dtTempTime.Add(TimeSpan.FromHours(offset * -1)); //add a negative = subtract.
            var newLocalTimeSpan = dtTempTime.TimeOfDay;
            var newLocalDateTime = new DateTime(newLocalTimeSpan.Ticks, DateTimeKind.Local);
