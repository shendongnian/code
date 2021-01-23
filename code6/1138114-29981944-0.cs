        static void Main(string[] args)
        {
            PrintAllDaylightSavingsAdjustmentDates();
            Console.ReadLine();
        }
        public static void PrintAllDaylightSavingsAdjustmentDates()
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo.AdjustmentRule[] adjustmentRules = timeZoneInfo.GetAdjustmentRules();
            for (int year = 2000; year < 2030; year++)
            {
                PrintDaylightSavingsAdjustmentDatesForYear(adjustmentRules, year);
            }
        }
        public static void PrintDaylightSavingsAdjustmentDatesForYear
            (
            TimeZoneInfo.AdjustmentRule[] adjustmentRules, 
            int year
            )
        {
            DateTime firstOfYear = new DateTime(year, 1, 1);
            foreach (TimeZoneInfo.AdjustmentRule adjustmentRule in adjustmentRules)
            {
                if ((adjustmentRule.DateStart <= firstOfYear) && (firstOfYear <= adjustmentRule.DateEnd))
                {
                    Console.WriteLine("In {0}, DST started on {1} and ended on {2}.",
                        year,
                        GetTransitionDate(adjustmentRule.DaylightTransitionStart, year).ToString("MMMM dd"),
                        GetTransitionDate(adjustmentRule.DaylightTransitionEnd, year).ToString("MMMM dd"));
                }
            }
        }
        public static DateTime GetTransitionDate
            (
            TimeZoneInfo.TransitionTime transitionTime,
            int year
            )
        {
            if (transitionTime.IsFixedDateRule)
            {
                return new DateTime(year, transitionTime.Month, transitionTime.Day);
            }
            else
            {
                DateTime transitionDate = new DateTime(year, transitionTime.Month, 1);
                transitionDate = transitionDate.AddDays(-1);
                for (int howManyWeeks = 0; howManyWeeks < transitionTime.Week; howManyWeeks++)
                {
                    transitionDate = transitionDate.AddDays(1);
                    while (transitionDate.DayOfWeek != transitionTime.DayOfWeek)
                    {
                        transitionDate = transitionDate.AddDays(1);
                    }
                }
                return transitionDate;
            }
        }
