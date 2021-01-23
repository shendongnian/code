                string weekdayName = "Mon,Tue,Wed,Thu,Fri,Sat,Sun";
                var wc = weekdayName.Split(',');
    
                if (wc.Any(str => str.Contains(DateTime.Today.DayOfWeek.ToString().Substring(0,3))))
                {
                 
                }
