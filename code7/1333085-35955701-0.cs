    List<DateTime> saturdays = new List<DateTime>();
            for(int i=0;i<DateTime.DaysInMonth(year, month), i++)
            {
                DateTime dt = new DateTime(year, month, i);
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                    saturdays.Add(dt);
            }
