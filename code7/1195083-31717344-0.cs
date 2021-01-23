        /// <summary> Get days in a week </summary>
        /// <param name="year">Number of year</param>
        /// <param name="month">Number of month. From 1 to 12</param>
        /// <param name="week">Number of week. From 1 to 5</param>
        /// <returns>Count of days</returns>
        public static int DaysInWeek(int year, int month, int week)
        {
            var weekCounter = 1;
            var daysCounter = 0;
            var dayInMonth = DateTime.DaysInMonth(year, month);
            for (var i = 1; i <= dayInMonth; i++)
            {
                ++daysCounter;
                var date = new DateTime(year, month, i);
                if (date.DayOfWeek == DayOfWeek.Sunday || i == dayInMonth)
                {
                    if (weekCounter == week)
                        return daysCounter;
                    weekCounter++;
                    daysCounter = 0;
                }
            }
            return 7;
        }
