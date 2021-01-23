    [XmlRoot("GAME")]
        public class Game
        {
            [XmlElement("EVENTS")]
            public Events Events { get; set; }
    
            [XmlElement("OBJECTS")]
            public GameObject GameObject { get; set; }
        }
    
    
        public class Events
        {
            [XmlElement("EVENTS")]
            public GameEvent Event;
        }
    
        public class Object
        {
            [XmlElement("object")]
            public GameObject GameObject;
        }
        public class GameEvent
        {
            [XmlElement("eventID")]
            public int eventID;
    
            [XmlElement("eventDescription")]
            public String eventDescription;
    
            [XmlElement("hasEventOccured")]
            public int hasEventOccured;
        }
    
        public class GameObject
        {
            [XmlElement("squareID")]
            public int squareID;
    
            [XmlElement("objectID")]
            public int objectID;
    
            [XmlElement("objectDescription")]
            public String objectDescription;
    
            [XmlElement("objectName")]
            public String objectName;
        }
