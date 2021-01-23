        public DailyTimeIntervalTriggerImpl GetNextTrigger(int minHour, int maxHour)
        {
            var random = new Random();
            int randomHour = random.Next(minHour, maxHour);
            int randomMinute = random.Next(0, 59);
            var nextDayOfWeek = DateTime.Now.AddDays(1).DayOfWeek;
            var daysOfWeek = new Quartz.Collection.HashSet<System.DayOfWeek>() { nextDayOfWeek };
            var trigger = new DailyTimeIntervalTriggerImpl
            {
                DaysOfWeek = daysOfWeek,
                StartTimeUtc = DateTime.UtcNow,
                StartTimeOfDay = new TimeOfDay(randomHour, randomMinute, 0),
                TimeZone = TimeZoneInfo.Utc
            };
            return trigger;
        }
