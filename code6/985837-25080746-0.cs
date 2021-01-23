        public IList<string> GetDays(int year)
        {
            var days = new List<string>();
            var start = new DateTime(year, 1, 1);
            while (start.Year == year)
            {
                days.Add(start.ToString("dd.MM.yyyy"));
                start = start.AddDays(1);
            }
            return days;
        }
