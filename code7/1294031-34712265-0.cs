    //use Sunday_Monday midnight as reference
                TimeSpan friday_3PM = new TimeSpan(4, 15, 0, 0); 
                TimeSpan sunday_7PM = new TimeSpan(6, 19, 0, 0); 
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now - now.AddDays(-1 * (((int)now.DayOfWeek + 6) % 7)).Date;
                if((timeSpan < friday_3PM) || (timeSpan > sunday_7PM))
                {
                }
