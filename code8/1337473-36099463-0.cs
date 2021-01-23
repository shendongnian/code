               DateTime startDate = DateTime.Parse("3/28/2016");
                DateTime endDate = DateTime.Parse("5/27/2016");
                List<DateTime> dates = new List<DateTime>();
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    dates.Add(date);
                }
                var groupedDays = dates.AsEnumerable()
                    .GroupBy(x => x.DayOfWeek)
                    .OrderBy(x => x.Key)
                    .Where(x => ((int)x.Key >= 1) && ((int)x.Key <= 5));
                foreach (var group in groupedDays)
                {
                    foreach (DateTime day in group)
                    {
                        Console.WriteLine(day.ToString("dddd, dd MMMM yyyy"));
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
