    void Main()
    {
        var start = new DateTime(2014, 10, 27);
        var end = new DateTime(2015, 02, 15);
        
        var daysPerMonth = new Dictionary<string, int>();
        
        var currentMonth = new DateTime(start.Year, start.Month, 1);
        while (true)
        {
            // Handle start and end in same month.
            if (start.ToString("MMyyyy") == currentMonth.ToString("MMyyyy") && end.ToString("MMyyyy") == currentMonth.ToString("MMyyyy"))
            {
                daysPerMonth.Add(currentMonth.ToString("MMyyyy"), end.Day - start.Day);
                break;
            }
            
            // Handle last month. 
            if (currentMonth.ToString("MMyyyy") == end.ToString("MMyyyy"))
            {
                daysPerMonth.Add(currentMonth.ToString("MMyyyy"), DateTime.DaysInMonth(end.Year, end.Month) - end.Day);
                break;
            }
            
            // Handle first month.
            if (currentMonth.ToString("MMyyyy") == start.ToString("MMyyyy"))
            {
                daysPerMonth.Add(currentMonth.ToString("MMyyyy"), DateTime.DaysInMonth(start.Year, start.Month) - start.Day);
            }
            // Handle full month.
            else
            {
                daysPerMonth.Add(currentMonth.ToString("MMyyyy"), DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month));
            }
            currentMonth = currentMonth.AddMonths(1);
        }
        // daysPerMonth: 
        // {
        //    { "102014", 4 },
        //    { "112014", 30 },
        //    { "122014", 31 },
        //    { "012015", 31 },
        //    { "022015", 13 }
        // }
    }
