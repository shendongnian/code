    public class TimeStamp
        {
            private string _HourList;
            private string _DayList;
            private string[] _DaysOfWeek;
            private string[] _HoursOfDay;
            public string[] HoursOfDay
            {
                get { return _HoursOfDay; }
                set
                {
                    _HoursOfDay = value;
                    _HourList = String.Join("|", value);
                }
            }
            public int ID { get; set; }
            public string[] DaysOfWeek
            {
                get { return _DaysOfWeek; }
                set
                {
                    _DaysOfWeek = value;
                    _DayList = String.Join("|", value);
                }
            }
            public string DayLis
            {
                get { return _DayList; }
            }
            public string HourList
            {
                get { return _HourList; }
            }
        }
