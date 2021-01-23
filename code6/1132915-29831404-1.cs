    public class Item
    {
        public Item()
        {
            this.Day = DateTime.Now.DayOfWeek;
            this.Time = DateTime.Now.TimeOfDay;
        }
        public DayOfWeek Day { get; set; }
        public TimeSpan Time { get; set; }
        public override string ToString()
        {
            return String.Format("{0}, {1}", this.Day, this.Time);
        }
    }
