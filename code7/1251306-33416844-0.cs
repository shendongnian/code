    public interface ITimeProvider
    {
        DateTime Now { get; }
        string ToShortDateString();
    }
    public class DateTimeProvider : ITimeProvider
    {
    
        private DateTime _date;
    
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    
        public  DateTimeProvider()
        {
            _date = new DateTime();
        }
        public string ToShortDateString()
        {
            return _date.ToShortDateString();
        }
    }
    public class RemoteTimeProvider : ITimeProvider
    {
        public DateTime Now
        {
            get 
            { 
                using(var client = new WebClient())
                {
                    var timeString = client.DownloadString(http://www.timeapi.org/utc/now);
                    return DateTime.Parse(timeString, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).ToLocalTime()
                }
                
            }
        }
    
        public  DateTimeProvider()
        {
            
        }
        public string ToShortDateString()
        {
            //ToDo
        }
    }
