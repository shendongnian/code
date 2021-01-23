    public class MyEvent
    {
        public int EventId{get;set;}
        public MyDate StartDate{get;set;}
        public DateTime MyStartDate { get { return DateTime.Parse(StartDate.MMDDYYYYHHMMSS); } }
    }
    var sorted = myEvents.OrderByDescending(e => e.MyStartDate);
