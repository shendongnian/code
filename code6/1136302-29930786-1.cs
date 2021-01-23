    public class FieldBookingMessageThread : MessageThread, ISoftDeletable, ITimeStamps, ICreatedBy
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FieldBookingMessageThreadID { get; set; }
    }
