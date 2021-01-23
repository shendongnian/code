                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddDays(83);
                List<DateTime> dates = new List<DateTime>();
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    dates.Add(date);
                }
                var groupedDays = dates.AsEnumerable()
                    .GroupBy(x => x.Subtract(startDate).Days % 14)
                    .OrderBy(x => x.Key)
                    .Where(x => ((int)x.FirstOrDefault().DayOfWeek >= 1) && ((int)x.FirstOrDefault().DayOfWeek <= 5));
                foreach (var group in groupedDays)
                {
                    foreach (DateTime day in group)
                    {
                        Console.WriteLine(day.ToString("dddd, dd MMMM yyyy"));
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
