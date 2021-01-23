    public class MessageContent
    {
    [Key]
    [ForeignKey("Message")]
    public Guid MessageId {get; set;}
    //Other fields
    public virtual Message Message {get;set;}
    [ForeignKey("Reason")]
    public Guid? ReasonId {get;set;}
    public virtual Message Reason {get;set;}
    
    [ForeignKey("Report")]
    public Guid? ReportId {get;set;}
    public virtual Message Report {get;set;}
    }
