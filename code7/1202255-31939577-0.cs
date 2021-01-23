    for (DateTime date = Start_Date; date <= End_Date; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                yield return date;
            }
        }
