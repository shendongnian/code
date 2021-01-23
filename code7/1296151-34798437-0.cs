    public class Attendance
    {
        public string Id { get; set; }
        public int TimeInMinutes { get; set; }
        public int Code { get; set; }
        public string Date { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Id, TimeInMinutes, Date);
        }
        }
