            public static DateTime GetNextWeekday(this DateTime dateTime, DayOfWeek day)
            {
                // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
                int daysToAdd = ((int)day - (int)dateTime.DayOfWeek + 7) % 7;
                return dateTime.AddDays(daysToAdd);
            }
