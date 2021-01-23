    public class SharedManWoman {
       public long Id { get; set; }
    
       [InverseProperty("Sender")]
       public ICollection<UserMessage> SenderMessages { get; set; }
    
       [InverseProperty("Receiver")]
       public ICollection<UserMessage> ReceiverMessages { get; set; }
    }
    
    public class UserMessage {
    
       [Key]
       public long Id { get; set; }
    
       // Note that these are NULLABLE
       public long? SenderIdFK { get; set; }
       public long? ReceiverIdFK { get; set; }
    
    
       [ForeignKey("SenderIdFK")]
       public virtual SharedManWoman Sender { get; set; }
    
       [ForeignKey("ReceiverIdFK")]
       public virtual SharedManWoman Receiver { get; set; }
    }
