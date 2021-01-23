    [Serializable]
    [XmlRoot(ElementName = "events")]
    public class Events {
       public Events()
       {
        EventList = new List<Event>();
       }
       [XmlElement(ElementName="event")]
       List<Event> EventList {get; set;}
    }
   
    [Serializable]
    public class Event {
      [XmlAttribute("eventid")
      public string eventid {get; set;}
        .......
      
     [XmlElement(ElementName="timezone")]
      public string timezone {get; set;}
    }
