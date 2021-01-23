            static void Main(string[] args)
            {
                DateTime today = DateTime.Now;
                if((today.DayOfWeek == DayOfWeek.Monday) && (today > new DateTime(today.Year, today.Month, today.Day, 12, 0, 0)))
                {
                    today.AddDays(1);
                }
                int offsetToMonday = (7 - ((int)today.DayOfWeek + 6)) % 7;
                DateTime nextMonday = today.AddDays(offsetToMonday);
                DateTime startDate = (nextMonday.DayOfYear / 7 % 2) == 0 ? nextMonday : nextMonday.AddDays(7);
                DateTime endDate = startDate.AddDays(83);
                List<DateTime> dates = new List<DateTime>();
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    dates.Add(date);
                }
                var groupedDays = dates.AsEnumerable()
                    .GroupBy(x => x.Subtract(startDate).Days % 14)
                    .OrderBy(x => x.Key)
                    .Where(x => x.Key == 0);
                foreach (var group in groupedDays)
                {
                    foreach (DateTime day in group)
                    {
                        Console.WriteLine(day.ToString("dddd, dd MMMM yyyy"));
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
