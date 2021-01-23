    [DataContract]
    public class Agent
    {       
      // included in JSON
      [DataMember]
      public int AgentId { get; set; }
      [DataMember]
      public string AgentName { get; set; }
      // ignored
      public bool IsAssigned { get; set; }
      public bool IsLoggedIn { get; set; }  
    }
