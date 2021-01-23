    [DataContract]
    public class Container
    {
      [DataMember(Name="ID")]
      public string ID { get; set; }
      [DataMember(Name="fd")]
      public Graph[] fd { get; set; }
    }
    [DataContract]
    public class Graph
    {
      [DataMember(Name="title")]
      public string Title { get; set; }
      [DataMember(Name="type")]
      public string Type { get; set; }
    }
