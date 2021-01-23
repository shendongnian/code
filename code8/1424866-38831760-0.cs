    public string ConvertToDayHourMinSec(DateTime firstTime, DateTime secondTime)
        {
            var timeTaken = new TimeSpan(firstTime.Ticks - secondTime.Ticks);
            var days = timeTaken.ToString("%d"); 
            var hms = timeTaken.ToString(@"hh\:mm\:ss");
            return days + " days, " + hms;
        }
