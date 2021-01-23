    public class TimeSlotInfo
    {
        public int DayOfMonth { get; set; }
        public List<TimeSlotRange> TimeSlots { get; set; }
        public TimeSlotInfo()
        {
            TimeSlots = new List<TimeSlotRange>();
        }
    }
    public class TimeSlotRange
    {
        public TimeSlotItem Start { get; set; }
        public TimeSlotItem End { get; set; }
    }
    public class TimeSlotItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public int SecondsInHour { get; set; }
        public string TimezoneStr { get; set; }
        public string BST { get; set; }
        public int SomeNum { get; set; }
        public DateTime AsDateTime
        {
            get { return new DateTime(Year, Month, Day, Hour, Minute, Second); }
        }
        public static TimeSlotItem CreateFromJTokenList(List<JToken> tokenList)
        {
            try
            {
                var result = new TimeSlotItem
                {
                    Year = tokenList[0].Value<int>(),
                    Month = tokenList[1].Value<int>(),
                    Day = tokenList[2].Value<int>(),
                    Hour = tokenList[3].Value<int>(),
                    Minute = tokenList[4].Value<int>(),
                    Second = tokenList[5].Value<int>(),
                    SecondsInHour = tokenList[6].Value<int>(),
                    TimezoneStr = tokenList[7].Value<string>(),
                    BST = tokenList[8].Value<string>(),
                    SomeNum = tokenList[9].Value<int>()
                };
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
