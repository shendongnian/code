    [DataContract]
    public class MyObject
    {
       [DataMember(Name = "Event_Title")]
       public string Title { get; set; }
       [DataMember]
       public string Details { get; set; }
    }
