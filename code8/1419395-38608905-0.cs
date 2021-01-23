        public class AppSelection
    {
        public string name { get; set; }
        public bool selected { get; set; }
    }
    
    public class DateSelection
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    
    public class EventType
    {
        public string name { get; set; }
        public bool selected { get; set; }
    }
    
    public class RootObject
    {
        public List<AppSelection> appSelection { get; set; }
        public DateSelection dateSelection { get; set; }
        public List<EventType> eventTypes { get; set; }
    }
    change this model to your model and then try hope it will useful for you
