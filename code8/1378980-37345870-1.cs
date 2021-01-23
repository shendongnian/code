    [DataContact]
    public class EventDTO {
   
      [DataMember]
      public int Id { get; set; }
      [DataMember]
      public string EventName { get; set; }
      [DataMember]
      public TimeSpan StartTime { get; set; }
      [DataMember]
      public TimeSpan EndTime {get;set;}
    }
