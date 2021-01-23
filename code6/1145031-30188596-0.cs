    [DataContract]
    public class Schedule {
         [DataMember("scheduleID")]
         public int ID { get; set; }
         [DataMember("scheduleName")]
         public string Name { get; set; }
     }
