        public static DateTime GetNextDayOfWeek(DateTime _date, DayOfWeek _dayOfWeek)
        {
            DateTime Result;
            int diff = _date.DayOfWeek - _dayOfWeek;
            if (diff == 0 && _date.Hour * 100 + _date.Minute <= 1200)
                return _date;
            if (diff < 0)
            {
                diff += 7;
            }
            Result = _date.AddDays(-1 * diff).Date;
            if (Result <= _date)
                Result = Result.AddDays(7);
            return Result;
        }
