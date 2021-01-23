    public class ActionsEntry
        {
            public ActionsEntry() { Actions = new List<Action>(); }
            [XmlElement("Action")]
            public List<Action> Actions { get; set; }
    
        }
    
        public class Action
        {
            public int X { get; set; }
            public int Y { get; set; }
    
            public string Text { get; set; }
    
            [XmlElement("interval")]
            public string Interval { get; set; }
            public int Type { get; set; }
    
        }
