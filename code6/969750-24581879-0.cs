        /// <summary>
        /// Check if a time falls inside a repeating daily event of a given duration.
        /// </summary>
        /// <param name="spawnTime">Start time of an event</param>
        /// <param name="runTime">Duration of the event</param>
        /// <param name="now">Time to test</param>
        /// <returns>true if the test time is inside the duration of the specified event.</returns>
        public static bool IsDailyEventActive(DateTime spawnTime, TimeSpan runTime, DateTime now)
        {
            // Are we inside an event that started today?
            DateTime spawnTimeToday = now.Date + spawnTime.TimeOfDay;
            if (now >= spawnTimeToday && now <= spawnTimeToday + runTime)
                return true;
            // Are we still inside an event that started yesterday?
            DateTime spawnTimeYesterday = now.Date.AddDays(-1) + spawnTime.TimeOfDay;
            if (now >= spawnTimeYesterday && now <= spawnTimeYesterday + runTime)
                return true;
            return false;
        }
