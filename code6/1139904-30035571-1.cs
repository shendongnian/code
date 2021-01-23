    [DataContract]
    public class OrderFault
    {
    [DataMember]
    public int OrderId { get; set; } 
    [DataMember]
    public string Message { get; set; }
    }
