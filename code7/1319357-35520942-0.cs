    public class Log
    {
        public int ID { get; set; }
        public string Agent { get; set; }
        public DateTime Date { get; set; }
        public Log(int id, string agent, DateTime date)
        {
            ID = id;
            Agent = agent;
            Date = date;
        }
    }
