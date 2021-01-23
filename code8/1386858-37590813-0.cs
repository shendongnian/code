    public static class DateTimeExtension
    {
        // should of course be in pascal case ;)
        public static int getMillisOfDay(this DateTime dateTime)
        {
            return (int) dateTime.TimeOfDay.TotalMilliseconds;
        }
    }
    int millisOfDay = DateTime.Now.getMillisOfDay();
