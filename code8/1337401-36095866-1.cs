    public class ActionsEntry
    {
        public Action Action { get; set; }
    }
    public class Action
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Text { get; set; }
        [XmlIgnore]
        public float interval { get; set; }
        private string _intervalString;
        [XmlElement("interval")]
        public string IntervalString
        {
            get
            {
                return _intervalString;
            }
            set
            {
                _intervalString = value;
                if (!string.IsNullOrEmpty(value))
                {
                    interval = float.Parse(value, CultureInfo.InvariantCulture);
                }
            }
        }
        public int Type { get; set; }
    }
 
