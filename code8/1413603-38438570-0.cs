    public static class DateTimeHelper
    {
        public static PersianDayOfWeek PersionDayOfWeek(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return PersianDayOfWeek.Shanbe;
                case DayOfWeek.Sunday:
                    return PersianDayOfWeek.Yekshanbe;
                case DayOfWeek.Monday:
                    return PersianDayOfWeek.Doshanbe;
                case DayOfWeek.Tuesday:
                    return PersianDayOfWeek.Seshanbe;
                case DayOfWeek.Wednesday:
                    return PersianDayOfWeek.Charshanbe;
                case DayOfWeek.Thursday:
                    return PersianDayOfWeek.Panjshanbe;
                case DayOfWeek.Friday:
                    return PersianDayOfWeek.Jome;
                default:
                    throw new Exception();
            }
        }
        public enum PersianDayOfWeek
        {
            Shanbe=1,
            Yekshanbe=2,
            Doshanbe=3,
            Seshanbe=4,
            Charshanbe=5,
            Panjshanbe=6,
            Jome=7
        }
    }
