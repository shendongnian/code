            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(15);
            var rusultDictionary = new Dictionary<DayOfWeek, int>();
            while (!startDate.Date.Equals(endDate.Date))
            {
                rusultDictionary[startDate.DayOfWeek] = rusultDictionary.ContainsKey(startDate.DayOfWeek) ? rusultDictionary[startDate.DayOfWeek] + 1 : 1;
                startDate = startDate.AddDays(1);
            }
