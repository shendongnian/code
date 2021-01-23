    static public List<string> GetDates(DateTime start_date, DateTime end_date)
        {
            List<string> days_list = new List<string>();
             for (DateTime date = start_date; date <= end_date; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                     days_list.Add(date.ToShortDateString());
            }
    
            return days_list;
