    public static class DateTimeExtensions
    {
        public static void FindInstanceNextMonth(DateTime Now, DayOfWeek day, int instance)
        {
            DateTime firstDayOfNextMonth = new DateTime(Now.Year, Now.Month + 1, 1);
            int count = 0;
            if (firstDayOfNextMonth.DayOfWeek == day)
                count = 1;
            while (count != instance)
            {
                firstDayOfNextMonth = firstDayOfNextMonth.AddDays(1);
                if (firstDayOfNextMonth.DayOfWeek == day)
                    count++;
            }
            Console.WriteLine(firstDayOfNextMonth);
        }
    }
