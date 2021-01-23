    public class Attendance
    {
        public int Id { get; set; }
        public int TimeInMinutes { get; set; }
        public string Date { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Id, TimeInMinutes, Date);
        }
    }
