     void CalculateHourse()
        {
            try
            {
                DateTime start = DateTime.ParseExact("04/02/2020 16:00","dd/MM/yyyy HH:mm",null,System.Globalization.DateTimeStyles.None);
                DateTime end = DateTime.ParseExact("09/02/2020 10:00", "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None);
                List<DateTime> holidays = new List<DateTime>();
                holidays.Add(new DateTime(2020, 02, 05));
                holidays.Add(new DateTime(2020, 02, 06));
                holidays.Add(new DateTime(2020, 02, 07));
                holidays.Add(new DateTime(2020, 02, 08));
                int count = 0;
                for (var i = start; i < end; i = i.AddHours(1))
                {
                    if (i.DayOfWeek != DayOfWeek.Friday && i.DayOfWeek != DayOfWeek.Saturday)
                    {
                        //if (holidays.Any(x=>x.Date.ToString("d") == i.Date.ToString("d")))
                        if(!holidays.Any(x=>x.Day == i.Day && x.Month == i.Month && x.Year == i.Year))
                        {
                            if (i.TimeOfDay.Hours >= 9 && i.TimeOfDay.Hours <= 17)
                            {
                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine(count);
                Console.Read();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
