    public class Event
    {
        [Key]
        public int Id { get; set; }
        public DateTime EventDate { get; set; }       
        public virtual ConsumerNM Consumer { get; set; }
        [ForeignKey("Consumer")]
        public int FK_LEADCONSUMER { get; set; }
        
        [ForeignKey("Consumer")]
        public int FK_LEADMETA { get; set; }
    }
