            DateTime dt = new DateTime(yr, mnth, 1);
            DateTime newdate = new DateTime();
            if (dt.DayOfWeek == DayOfWeek.Monday)
            {
                newdate = dt.AddDays(((week - 1) * 7) + 5);
            }
            else
            {
                newdate = dt.AddDays((8 - (int)dt.DayOfWeek) % 7 + ((week - 2) * 7) + 5);
            }
            return newdate;
        }
