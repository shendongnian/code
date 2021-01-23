    public class Rule
    {
        public string name { get; set; }
        public bool enabled { get; set; }
        public Condition[ ] conditions { get; set; }
        public Actions actions { get; set; }
    }
    public class Actions
    {
        public int period { get; set; }
        public bool single { get; set; }
        public Act[ ] act { get; set; }
    }
    public class Act
    {
        public string type { get; set; }
        public string uid { get; set; }
        public string message { get; set; }
    }
    public class Condition
    {
        public string type { get; set; }
        public string time { get; set; }
        public string days { get; set; }
        public string uid { get; set; }
        public int setpoint1 { get; set; }
        public int setpoint2 { get; set; }
        public int criterion { get; set; }
    }
