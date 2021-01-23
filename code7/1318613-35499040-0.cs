    [DataContract]
    public class ServiceResponse<T>
    {
      [DataMember]
      ServiceStatus Status { get; set; }
      [DataMember]
      T Payload { get; set; }
    }
