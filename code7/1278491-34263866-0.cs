    public class EntityToOrder
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public long OtherId { get; set; }
        
        [ForeignKey("OtherId")]
        public OtherEntity OtherEntity{ get; set; }
    }
