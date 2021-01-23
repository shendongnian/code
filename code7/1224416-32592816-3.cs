    public class MyEvent
    {
        public MyEvent(int eventId, MyDate startDate)
        {
            EventId = eventId;
            StartDate = startDate;
            MyStartDate = DateTime.Parse(StartDate.MMDDYYYYHHMMSS);
        }
        public int EventId{get; private set;}
        public MyDate StartDate{get; private set;}
        public DateTime MyStartDate { get; private set; }
    }
