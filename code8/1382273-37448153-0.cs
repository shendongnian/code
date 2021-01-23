    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class TimeSinceBuildsReader
    {
        public virtual IReadOnlyList<DateTime> TimesWhenBuildsOccurred(string timeSinceBuildsFilePath)
        {
            if (!File.Exists(timeSinceBuildsFilePath))
            {
                return new List<DateTime>();
            }
            var lines = File.ReadAllLines(timeSinceBuildsFilePath);
            var list = new List<DateTime>(lines.Length);
            var now = DateTime.Now;
            foreach (var line in lines)
            {
                var split = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(l => l.Trim()).ToArray();
                if (split.Length % 2 != 0)
                {
                    continue;
                }
                switch (split.Length)
                {
                    case 2:
                        list.Add(now.Subtract(getTimePassed(now, split[0], split[1])));
                        break;
                    case 4:
                        var firstDuration = getTimePassed(now, split[0], split[1]);
                        var secondDuration = getTimePassed(now, split[2], split[3]);
                        list.Add(now.Subtract(firstDuration).Subtract(secondDuration));
                        break;
                }
            }
            return list;
        }
        private static TimeSpan getTimePassed(DateTime now, string number, string durationType)
        {
            var num = int.Parse(number);
            if (durationType.Contains("month") || durationType.Contains("mo"))
            {
                var numberOfDays = now.DayOfYear - now.AddMonths(num * -1).DayOfYear;
                return TimeSpan.FromDays(numberOfDays);
            }
            if (durationType.Contains("day"))
            {
                return TimeSpan.FromDays(num);
            }
            if (durationType.Contains("hour") || durationType.Contains("hr"))
            {
                return TimeSpan.FromHours(num);
            }
            if (durationType.Contains("minute") || durationType.Contains("min"))
            {
                return TimeSpan.FromMinutes(num);
            }
            if (durationType.Contains("second") || durationType.Contains("sec"))
            {
                return TimeSpan.FromSeconds(num);
            }
            throw new NotImplementedException("Could not parse duration type from input " + durationType);
        }
    }
