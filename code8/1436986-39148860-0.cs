            var timeSpanList = new List<TimeSpan>();
            CultureInfo provider = CultureInfo.InvariantCulture;
            timeSpanList.Add(new TimeSpan(DateTime.ParseExact("23.08.2016 10:31:38", "dd.MM.yyyy H:mm:ss", provider).Ticks - DateTime.ParseExact("22.08.2016 21:00:00", "dd.MM.yyyy H:mm:ss", provider).Ticks));
            timeSpanList.Add(new TimeSpan(DateTime.ParseExact("24.08.2016 14:32:26", "dd.MM.yyyy H:mm:ss", provider).Ticks - DateTime.ParseExact("24.08.2016 21:00:00", "dd.MM.yyyy H:mm:ss", provider).Ticks));
            timeSpanList.Add(new TimeSpan(DateTime.ParseExact("17.08.2016 8:36:51", "dd.MM.yyyy H:mm:ss", provider).Ticks - DateTime.ParseExact("01.01.2016 21:00:00", "dd.MM.yyyy H:mm:ss", provider).Ticks));
            timeSpanList.Add(new TimeSpan(DateTime.ParseExact("17.08.2016 8:34:27", "dd.MM.yyyy H:mm:ss", provider).Ticks - DateTime.ParseExact("15.03.2016 21:00:00", "dd.MM.yyyy H:mm:ss", provider).Ticks));
            var totalTicks = 0L;
            foreach(var ts in timeSpanList)
            {
                totalTicks += ts.Ticks;
            }
            var avgTicks = totalTicks / timeSpanList.Count;
            var avgTimeSpan = new TimeSpan(avgTicks);
